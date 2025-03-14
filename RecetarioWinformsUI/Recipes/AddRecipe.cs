using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Recipes
{
    public partial class AddRecipe : Form
    {
        private readonly List<RecipeIngredient> Ingredients = new();
        private readonly List<RecipeSubRecipe> SubRecipes = new();

        private readonly IRecipesBLL RecipesBLL;
        private readonly IRecipeIngredientsBLL RecipeIngredientsBLL;
        private readonly IRecipeSubRecipesBLL RecipeSubRecipesBLL;
        private readonly IUnitsBLL UnitsBLL;
        private readonly IIngredientsBLL IngredientsBLL;

        public AddRecipe(IRecipesBLL recipesBLL, IRecipeIngredientsBLL recipeIngredientsBLL, IRecipeSubRecipesBLL recipeSubRecipesBLL, IUnitsBLL unitsBLL, IIngredientsBLL ingredientsBLL)
        {
            InitializeComponent();

            RecipesBLL = recipesBLL;
            RecipeIngredientsBLL = recipeIngredientsBLL;
            RecipeSubRecipesBLL = recipeSubRecipesBLL;
            UnitsBLL = unitsBLL;
            IngredientsBLL = ingredientsBLL;

            CbUnitsDataBind();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();

            GlobalUIEvents.Instance.OnUnitAdded += OnUnitAdded;
            GlobalUIEvents.Instance.OnUnitUpdated += OnUnitUpdated;
            GlobalUIEvents.Instance.OnIngredientUpdated += OnIngredientUpdated;
            GlobalUIEvents.Instance.OnRecipeUpdated += OnRecipeUpdated;
        }

        #region Events

        private void OnUnitAdded(object sender, EventArgs e)
        {
            CbUnitsDataBind();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
        }

        private void OnUnitUpdated(object sender, EventArgs e)
        {
            CbUnitsDataBind();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
        }

        private void OnIngredientUpdated(object sender, EventArgs e)
        {
            CbUnitsDataBind();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
            RecalculateCosts();
        }

        private void OnRecipeUpdated(object sender, EventArgs e)
        {
            GvSubRecipesDataBind();
            RecalculateCosts();
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            var frmSelectRecipeIngredient = new SelectRecipeIngredient(
                Ingredients.Select(p => (int)p.Ingredient.Id),
                IngredientsBLL // Pasar el BLL de ingredientes
            );

            frmSelectRecipeIngredient.OnIngredientSelected += OnIngredientSelected;
            frmSelectRecipeIngredient.ShowDialog();
        }

        private void OnIngredientSelected(object sender, IngredientSelectedEventArgs e)
        {
   
            Ingredients.Add(e.RecipeIngredientSelected);
            GvIngredientsDataBind();
            RecalculateCosts();
        }

        private void BtnAddSubRecipe_Click(object sender, EventArgs e)
        {

            var frmSelectRecepeSubRecipe = new SelectRecipeSubRecipe(
                SubRecipes.Select(p => (int)p.SubRecipeId),
                RecipesBLL,
                UnitsBLL
            );

            frmSelectRecepeSubRecipe.OnSubRecipeSelected += OnSubRecipeSelected;
            frmSelectRecepeSubRecipe.ShowDialog();
        }


        private void OnSubRecipeSelected(object sender, SubRecipeSelectedEventArgs e)
        {
            SubRecipes.Add(e.SubRecipe);
            GvSubRecipesDataBind();
            RecalculateCosts();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnAddRecipe_Click(object sender, EventArgs e)
        {
            if (!ValidateRecipe())
            {
                return;
            }

            var newRecipeDTO = new RecipeDTO()
            {
                RecipeName = txtRecipeName.Text.Trim(),
                Efficiency = Convert.ToSingle(txtEfficiency.Value / 100),
                AmountProduced = Convert.ToSingle(txtAmount.Value),
                UnitId = Convert.ToInt32(cbUnits.SelectedValue),
                Ingredients = Ingredients.Select(p => new RecipeIngredientDTO()
                {
                    Ingredient = IngredientsBLL.GetIngredientById(p.Ingredient.Id), // Obtener el ingrediente
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency
                }).ToList(),
                SubRecipes = SubRecipes.Select(p => new RecipeSubRecipeDTO()
                {
                    SubRecipe = RecipesBLL.GetRecipe(p.SubRecipeId), // Obtener la subreceta
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency
                }).ToList()
            };

            var recipeId = RecipesBLL.CreateRecipe(newRecipeDTO); // Utilizamos el método CreateRecipe para insertar

            Parallel.ForEach(Ingredients, recipeIngredient =>
            {
                // Verificar si ya existe el ingrediente para la receta actual
                if (!RecipeIngredientsBLL.IngredientExistsInRecipe(recipeId, recipeIngredient.IngredientId))
                {
                    recipeIngredient.RecipeId = recipeId;
                    RecipeIngredientsBLL.CreateRecipeIngredient(new RecipeIngredientDTO()
                    {
                        Ingredient = IngredientsBLL.GetIngredientById(recipeIngredient.IngredientId),
                        Quantity = recipeIngredient.Quantity,
                        Efficiency = recipeIngredient.Efficiency
                    });
                }
            });

            // Y para subrecetas:
            Parallel.ForEach(SubRecipes, subRecipe =>
            {
                if (!RecipeSubRecipesBLL.SubRecipeExistsInRecipe(recipeId, subRecipe.SubRecipeId))
                {
                    subRecipe.RecipeId = recipeId;
                    RecipeSubRecipesBLL.CreateRecipeSubRecipe(new RecipeSubRecipeDTO()
                    {
                        SubRecipe = RecipesBLL.GetRecipe((int)subRecipe.SubRecipeId),
                        Quantity = subRecipe.Quantity,
                        Efficiency = subRecipe.Efficiency
                    });
                }
            });


            GlobalUIEvents.Instance.DispatchOnRecipeAdded(this, new EventArgs());
            MessageBox.Show("Receta creada exitosamente.", "Recetas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }


        private void TxtAmount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateCosts();
        }

        private void TxtEfficiency_ValueChanged(object sender, EventArgs e)
        {
            RecalculateCosts();
        }

        private void GvRecipeIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvRecipeIngredients.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (MessageBox.Show("¿Seguro quiere remover este Ingrediente?", "Remover Ingrediente", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                var selectedIngredientId = gvRecipeIngredients.Rows[e.RowIndex].Cells["IngredientId"].Value as long?;

                Ingredients.RemoveAll(p => p.IngredientId == selectedIngredientId);
                GvIngredientsDataBind();
                RecalculateCosts();
            }
        }

        private void GvSubRecipe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSubRecipe.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (((DataGridViewButtonColumn)gvSubRecipe.Columns[e.ColumnIndex]).Name == "btnRemoveRecipeSubRecipe")
                {
                    if (MessageBox.Show("¿Seguro quiere remover esta SubReceta?", "Remover SubReceta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }

                    var selectedRecipeId = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
                    SubRecipes.RemoveAll(p => p.SubRecipeId == selectedRecipeId);
                    GvSubRecipesDataBind();
                    RecalculateCosts();
                }
                else if (((DataGridViewButtonColumn)gvSubRecipe.Columns[e.ColumnIndex]).Name == "btnViewRecipeSubRecipeView")
                {
                    var recipeId = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
                    var viewSubRecipeForm = new ViewRecipe((int)recipeId,RecipesBLL);
                    viewSubRecipeForm.Show();
                }
            }
        }

        private void GvSubRecipe_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var recipeId = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
            var viewSubRecipeForm = new ViewRecipe((int)recipeId, RecipesBLL);
            viewSubRecipeForm.Show();
        }

        #endregion

        #region Private Methods

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL.GetAllUnits().Select(p => new { p.Id, p.Abbreviation }).ToList();
            cbUnits.Update();
        }

        private void GvIngredientsDataBind()
        {
            gvRecipeIngredients.DataSource = Ingredients
                .Where(p => p.Ingredient != null) // Filtrar ingredientes que no sean null
                .Select(p => new
                {
                    IngredientId = p.IngredientId,
                    IngredientName = p.Ingredient?.IngredientName ?? "Sin Nombre", // Verificar si el nombre es null
                    IngredientQuantity = p.Quantity,
                    IngredientUnit = p.Ingredient?.UnitId != null
                        ? UnitsBLL.GetUnit((int)p.Ingredient.UnitId)?.Abbreviation ?? "Sin Unidad"  // Consultar el nombre de la unidad usando UnitsBLL
                        : "Sin Unidad", // Si UnitId es nulo
                    IngredientEfficiency = p.Efficiency.ToString("P"),
                    IngredientCost = (p.Ingredient != null && p.Ingredient.AmountSoldBy > 0) ?
                        ((p.Ingredient.Cost / p.Ingredient.AmountSoldBy) * p.Quantity).ToString("C2") : "Costo no disponible"
                }).ToList();

            gvRecipeIngredients.Refresh();
        }



        private void GvSubRecipesDataBind()
        {
            gvSubRecipe.DataSource = SubRecipes
                .Where(p => p.SubRecipe != null) // Verificar que SubRecipe no sea null
                .Select(p => new
                {
                    SubRecipeId = p.SubRecipeId,
                    SubRecipeName = p.SubRecipe?.RecipeName ?? "Sin Nombre", // Verificar si el nombre es null
                    SubRecipeQuantity = p.Quantity,
                    SubRecipeUnit = p.SubRecipe?.Unit?.Abbreviation ?? "Sin Unidad", // Verificar si la unidad es null
                    SubRecipeEfficiency = p.SubRecipe?.Efficiency.ToString("P") ?? "Sin Eficiencia", // Verificar si la eficiencia es null
                    SubRecipeCost = (p.SubRecipe != null) ?
                        RecipesBLL.CalculateRecipeCosts(p.SubRecipeId).ToString("C2") : "Costo no disponible" // Verificar si SubRecipe es null antes de calcular el costo
                }).ToList();

            gvSubRecipe.Refresh();
        }



        private void RecalculateCosts()
        {
            var ingredientsCost = Ingredients.Sum(q => (q.Ingredient.Cost / q.Ingredient.AmountSoldBy) * q.Quantity);
            txtIngredientCosts.Text = ingredientsCost.ToString("C2");

            var subRecipesCost = SubRecipes.Sum(q => RecipesBLL.CalculateRecipeCosts(q.SubRecipeId));
            txtSubRecipesCost.Text = subRecipesCost.ToString("C2");

            txtCost.Text = $"{ingredientsCost + subRecipesCost:C2}";
        }

        private bool ValidateRecipe()
        {
            if (string.IsNullOrEmpty(txtRecipeName.Text.Trim()))
            {
                MessageBox.Show("El nombre de la receta no puede estar vacío.", "Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRecipeName.Select();
                return false;
            }

            if (cbUnits.SelectedValue == null)
            {
                MessageBox.Show("No existen unidades en catálogo, es necesario tener al menos una en el sistema.", "Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbUnits.Select();
                return false;
            }

            if (!Ingredients.Any() && !SubRecipes.Any())
            {
                MessageBox.Show("Al menos un ingrediente o subreceta debe ser seleccionado.", "Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        #endregion
    }
}
