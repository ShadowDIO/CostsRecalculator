using System.Data;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;
using RecetarioWinformsUI.Helpers;

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

        public SelectRecipeSubRecipe(
            IEnumerable<int> usedRecipeIds,
            IRecipesBLL recipesBLL,
            IUnitsBLL unitsBLL)
        {
            UsedRecipeIds = usedRecipeIds.ToList();
            RecipesBLL = recipesBLL;
            UnitsBLL = unitsBLL;

            InitializeComponent();

            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            FetchRecipesAvailable();
            CbRecipesNameDataBind();
            CbUnitsDataBind();
        }

        private void FetchRecipesAvailable()
        {
            var recipes = RecipesBLL
                .GetAllRecipes(includeUnits: true, includeIngredientsAndSubRecipes: true)
                .Where(p => !UsedRecipeIds.Contains((int)p.Id));

            RecipesAvailable = recipes.ToList();
        }

        private void CbRecipesNameDataBind()
        {
            cbRecipeName.DataSource = RecipesAvailable;
            cbRecipeName.Update();

            cbRecipeName.AutoCompleteCustomSource
                .AddRange(RecipesAvailable.Select(p => p.RecipeName).ToArray());
            cbRecipeName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL
                .GetAllUnits()
                .Select(p => new { p.Id, p.Abbreviation })
                .ToList();
            cbUnits.Update();
        }

        private void TxtAmount_ValueChanged(object sender, EventArgs e) => RecalculateFields();
        private void TxtEfficiency_ValueChanged(object sender, EventArgs e) => RecalculateFields();

        private void CbRecipeName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbRecipeName.SelectedValue == null) return;

            RecalculateFields();

            var selected = RecipesAvailable
                .First(p => p.Id == (long)cbRecipeName.SelectedValue);

            gvRecipeIngredients.DataSource = selected.Ingredients.Select(p => new
            {
                Id = p.Ingredient.Id,
                IngredientName = StringHelper.TrimLongName(p.Ingredient.IngredientName),
                IngredientQuantity = p.Quantity,
                IngredientUnit = p.Ingredient.UnitName,
                IngredientEfficiency = p.Efficiency.ToString("P"),
                IngredientCost = ((p.Ingredient.Cost / p.Ingredient.AmountSoldBy) * p.Quantity)
                                        .ToString("C2")
            }).ToList();
            gvRecipeIngredients.Update();

            gvSubRecipe.DataSource = selected.SubRecipes.Select(p => new
            {
                SubRecipeId = p.SubRecipe.Id,
                SubRecipeName = StringHelper.TrimLongName(p.SubRecipe.RecipeName),
                SubRecipeQuantity = p.Quantity,
                SubRecipeUnit = p.SubRecipe.UnitName,
                SubRecipeEfficiency = $"{p.Efficiency:P}",
                SubRecipeCost = $"{RecipesBLL.CalculateRecipeCosts(p.SubRecipe):C2}"
            }).ToList();
            gvSubRecipe.Update();
        }

        private void RecalculateFields()
        {
            txtCalculatedEfficiency.Value = txtAmount.Value * txtEfficiency.Value;

            var selected = RecipesAvailable
                .First(p => p.Id == (long)cbRecipeName.SelectedValue);

            var ingredientsCost = selected.Ingredients
                .Sum(q => (q.Cost / q.Ingredient.AmountSoldBy) * q.Quantity);
            txtIngredientCosts.Text = ingredientsCost.ToString("C2");

            var subRecipesCost = selected.SubRecipes
                .Sum(q => RecipesBLL.CalculateRecipeCosts(q.SubRecipe));
            txtSubRecipesCost.Text = subRecipesCost.ToString("C2");

            txtCost.Text = $"{ingredientsCost + subRecipesCost:C2}";
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (cbRecipeName.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una subreceta.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sub = RecipesAvailable
                .FirstOrDefault(p => p.Id == (long)cbRecipeName.SelectedValue);
            if (sub == null)
            {
                MessageBox.Show("La subreceta seleccionada no fue encontrada.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selected = new RecipeSubRecipe
            {
                SubRecipeId = sub.Id,
                Quantity = Convert.ToDouble(txtAmount.Value),
                Efficiency = Convert.ToDouble(txtEfficiency.Value / 100),
                SubRecipe = new Recipe
                {
                    Id = sub.Id,
                    RecipeName = sub.RecipeName,
                    Efficiency = sub.Efficiency,
                    AmountProduced = sub.AmountProduced,
                    UnitId = sub.UnitId,
                    Unit = new Unit { Id = sub.UnitId, Abbreviation = sub.UnitName },
                    RecipeIngredients = sub.Ingredients
                                            .Select(i => new RecipeIngredient
                                            {
                                                IngredientId = i.Ingredient.Id,
                                                Quantity = i.Quantity,
                                                Efficiency = i.Efficiency
                                            }).ToList(),
                    RecipeSubRecipeRecipes = sub.SubRecipes
                                            .Select(sr => new RecipeSubRecipe
                                            {
                                                SubRecipeId = sr.SubRecipe.Id,
                                                Quantity = sr.Quantity,
                                                Efficiency = sr.Efficiency
                                            }).ToList()
                }
            };

            OnSubRecipeSelected?.Invoke(this, new SubRecipeSelectedEventArgs(selected));
            Close();
        }

        private void GvSubRecipe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSubRecipe.Columns[e.ColumnIndex] is DataGridViewButtonColumn btn && e.RowIndex >= 0
                && btn.Name == "btnViewRecipeSubRecipeView")
            {
                var id = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
                new ViewRecipe((int)id, RecipesBLL).Show();
            }
        }

        private void GvSubRecipe_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
            new ViewRecipe((int)id, RecipesBLL).Show();
        }

        /// <summary>
        /// Recorre recursivamente controles y suscribe Enter y MouseClick
        /// para hacer SelectAll() en TextBoxBase y NumericUpDown.
        /// </summary>
        private void AttachSelectAllBehavior(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBoxBase tb)
                {
                    tb.Enter += (s, e) => tb.SelectAll();
                    tb.MouseClick += (s, e) => tb.SelectAll();
                }
                else if (c is NumericUpDown nud)
                {
                    var inner = nud.Controls.OfType<TextBox>().FirstOrDefault();
                    if (inner != null)
                    {
                        inner.Enter += (s, e) => inner.SelectAll();
                        inner.MouseClick += (s, e) => inner.SelectAll();
                    }
                }

                if (c.HasChildren)
                    AttachSelectAllBehavior(c);
            }
        }
    }
}
