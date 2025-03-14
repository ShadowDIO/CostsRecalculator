using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;
using RecetarioWinformsUI.Helpers;
using System.Data;

namespace RecetarioWinformsUI.Recipes
{
    public partial class SelectRecipeSubRecipe : Form
    {
        public delegate void SubRecipeSelected(object sender, SubRecipeSelectedEventArgs e);
        public event SubRecipeSelected OnSubRecipeSelected;

        private List<int> UsedRecipeIds;

        private List<RecipeDTO> RecipesAvailable;

        private readonly IRecipesBLL RecipesBLL;
        private readonly IUnitsBLL UnitsBLL;

        public SelectRecipeSubRecipe(IEnumerable<int> usedRecipeIds, IRecipesBLL recipesBLL, IUnitsBLL unitsBLL)
        {
            UsedRecipeIds = usedRecipeIds.ToList();
            RecipesBLL = recipesBLL;
            UnitsBLL = unitsBLL;

            InitializeComponent();

            FetchRecipesAvailable();

            CbRecipesNameDataBind();

            CbUnitsDataBind();
        }

        private void FetchRecipesAvailable()
        {
            var recipes = RecipesBLL.GetAllRecipes(includeUnits: true, includeIngredientsAndSubRecipes: true)
                .Where(p => !UsedRecipeIds.Contains((int)p.Id));

            RecipesAvailable = recipes.ToList();
        }

        private void CbRecipesNameDataBind()
        {
            cbRecipeName.DataSource = RecipesAvailable;

            cbRecipeName.Update();

            cbRecipeName.AutoCompleteCustomSource.AddRange(RecipesAvailable.Select(p => p.RecipeName).ToArray());

            cbRecipeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL.GetAllUnits().Select(p => new { p.Id, p.Abbreviation })
                .ToList();

            cbUnits.Update();
        }

        private void TxtAmount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateFields();
        }

        private void TxtEfficiency_ValueChanged(object sender, EventArgs e)
        {
            RecalculateFields();
        }

        private void CbRecipeName_SelectedValueChanged(object sender, EventArgs e)
        {
            RecalculateFields();

            var selectedSubRecipe = RecipesAvailable.First(p => p.Id == (long)cbRecipeName.SelectedValue);

            gvRecipeIngredients.DataSource = selectedSubRecipe.Ingredients.Select(p => new
            {
                Id = p.Ingredient.Id, 
                IngredientName = StringHelper.TrimLongName(p.Ingredient.IngredientName),  
                IngredientQuantity = p.Quantity,
                IngredientUnit = p.Ingredient.UnitName, 
                IngredientEfficiency = p.Efficiency.ToString("P"),
                IngredientCost = ((p.Ingredient.Cost / p.Ingredient.AmountSoldBy) * p.Quantity).ToString("C2")  
            }).ToList();

            gvRecipeIngredients.Update();

            gvSubRecipe.DataSource = selectedSubRecipe.SubRecipes.Select(p => new
            {
                SubRecipeId = p.SubRecipe.Id,  
                SubRecipeName = StringHelper.TrimLongName(p.SubRecipe.RecipeName),  
                SubRecipeQuantity = p.Quantity,
                SubRecipeUnit = p.SubRecipe.UnitName, 
                SubRecipeEfficiency = $"{p.Efficiency:P}",
                SubRecipeCost = $"{RecipesBLL.CalculateRecipeCosts(p.SubRecipe):C2}",
            }).ToList();

            gvSubRecipe.Update();
        }


        private void RecalculateFields()
        {
            txtCalculatedEfficiency.Value = txtAmount.Value * txtEfficiency.Value;

            var selectedRecipe = RecipesAvailable.First(p => p.Id == (long)cbRecipeName.SelectedValue);

            var ingredientsCost = selectedRecipe.Ingredients.Sum(q => (q.Cost / q.Ingredient.AmountSoldBy) * q.Quantity);

            txtIngredientCosts.Text = ingredientsCost.ToString("C2");

            var subRecipesCost = selectedRecipe.SubRecipes
                            .Sum(q => RecipesBLL.CalculateRecipeCosts(q.SubRecipe));


            txtSubRecipesCost.Text = subRecipesCost.ToString("C2");

            txtCost.Text = $"{ingredientsCost + subRecipesCost:C2}";
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una receta
            if (cbRecipeName.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una subreceta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Buscar la subreceta seleccionada en la lista
            var subRecipeSelected = RecipesAvailable.FirstOrDefault(p => p.Id == (long)cbRecipeName.SelectedValue);

            // Verificar si se encontró la subreceta
            if (subRecipeSelected == null)
            {
                MessageBox.Show("La subreceta seleccionada no fue encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear el objeto RecipeSubRecipe
            var selectedRecipeSubRecipe = new RecipeSubRecipe
            {
                SubRecipeId = subRecipeSelected.Id,
                Quantity = Convert.ToDouble(txtAmount.Value),
                Efficiency = Convert.ToDouble(txtEfficiency.Value / 100),
                SubRecipe = new Recipe
                {
                    Id = subRecipeSelected.Id,
                    RecipeName = subRecipeSelected.RecipeName,
                    Efficiency = subRecipeSelected.Efficiency,
                    AmountProduced = subRecipeSelected.AmountProduced,
                    UnitId = subRecipeSelected.UnitId,
                    Unit = new Unit
                    {
                        Id = subRecipeSelected.UnitId,
                        Abbreviation = subRecipeSelected.UnitName
                    },
                    RecipeIngredients = subRecipeSelected.Ingredients.Select(i => new RecipeIngredient
                    {
                        IngredientId = i.Ingredient.Id,
                        Quantity = i.Quantity,
                        Efficiency = i.Efficiency
                    }).ToList(),
                    RecipeSubRecipeRecipes = subRecipeSelected.SubRecipes.Select(sr => new RecipeSubRecipe
                    {
                        SubRecipeId = sr.SubRecipe.Id,
                        Quantity = sr.Quantity,
                        Efficiency = sr.Efficiency
                    }).ToList()
                }
            };

            // Invocar el evento con la subreceta seleccionada
            OnSubRecipeSelected?.Invoke(this, new SubRecipeSelectedEventArgs(selectedRecipeSubRecipe));

            // Cerrar el formulario
            Close();
        }






        private void GvSubRecipe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSubRecipe.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (((DataGridViewButtonColumn)gvSubRecipe.Columns[e.ColumnIndex]).Name == "btnViewRecipeSubRecipeView")
                {
                    var recipeId = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;

                    var viewSubRecipeForm = new ViewRecipe((int)recipeId, RecipesBLL);

                    viewSubRecipeForm.Show();
                }
            }
        }

        private void GvSubRecipe_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var recipeId = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;

            var viewSubRecipeForm = new ViewRecipe((int)recipeId,RecipesBLL);

            viewSubRecipeForm.Show();
        }
    }
}
