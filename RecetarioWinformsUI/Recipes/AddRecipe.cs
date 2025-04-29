using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;
using System.Diagnostics;

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
            if (!ValidateRecipe()) return;

            var newRecipeDTO = new RecipeDTO
            {
                RecipeName = txtRecipeName.Text.Trim(),
                Efficiency = Convert.ToSingle(txtEfficiency.Value / 100),
                AmountProduced = Convert.ToSingle(txtAmount.Value),
                UnitId = Convert.ToInt32(cbUnits.SelectedValue),
                Ingredients = Ingredients.Select(p => new RecipeIngredientDTO
                {
                    Ingredient = IngredientsBLL.GetIngredientById(p.Ingredient.Id),
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency
                }).ToList(),
                SubRecipes = SubRecipes.Select(p => new RecipeSubRecipeDTO
                {
                    SubRecipe = RecipesBLL.GetRecipe(p.SubRecipeId),
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency
                }).ToList()
            };

            var recipeId = RecipesBLL.CreateRecipe(newRecipeDTO);

            foreach (var ri in Ingredients)
            {
                if (!RecipeIngredientsBLL.IngredientExistsInRecipe(recipeId, ri.IngredientId))
                {
                    RecipeIngredientsBLL.CreateRecipeIngredient(new RecipeIngredientDTO
                    {
                        RecipeId = recipeId,
                        Ingredient = IngredientsBLL.GetIngredientById(ri.IngredientId),
                        Quantity = ri.Quantity,
                        Efficiency = ri.Efficiency
                    });
                }
            }

            foreach (var sr in SubRecipes)
            {
                if (!RecipeSubRecipesBLL.SubRecipeExistsInRecipe(recipeId, sr.SubRecipeId))
                {
                    RecipeSubRecipesBLL.CreateRecipeSubRecipe(new RecipeSubRecipeDTO
                    {
                        RecipeId = recipeId,
                        SubRecipe = RecipesBLL.GetRecipe((int)sr.SubRecipeId),
                        Quantity = sr.Quantity,
                        Efficiency = sr.Efficiency
                    });
                }
            }

            GlobalUIEvents.Instance.DispatchOnRecipeAdded(this, EventArgs.Empty);
            MessageBox.Show("Receta creada exitosamente.", "Recetas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (gvRecipeIngredients.Columns[e.ColumnIndex] is DataGridViewButtonColumn btn
                && btn.Name == "btnRemoveRecipeIngredient")
            {
                if (MessageBox.Show(
                        "¿Seguro quiere remover este Ingrediente?",
                        "Remover Ingrediente",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) != DialogResult.Yes)
                {
                    return;
                }

                // Tomamos el ID *inmediatamente*...
                var cell = gvRecipeIngredients.Rows[e.RowIndex].Cells["IngredientId"];
                if (cell?.Value is not long id) return;

                // Pero la eliminación y el rebind los hacemos después:
                this.BeginInvoke((Action)(() =>
                {
                    Ingredients.RemoveAll(x => x.IngredientId == id);
                    GvIngredientsDataBind();
                    RecalculateCosts();
                }));
            }
        }


        private void GvSubRecipe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1) Filtrar clicks en encabezados o índices fuera de rango
            if (e.RowIndex < 0 || e.ColumnIndex < 0 ||
                e.RowIndex >= gvSubRecipe.Rows.Count ||
                e.ColumnIndex >= gvSubRecipe.Columns.Count)
            {
                return;
            }

            // 2) Solo reaccionar si es columna de botón
            if (!(gvSubRecipe.Columns[e.ColumnIndex] is DataGridViewButtonColumn btnCol))
                return;

            // 3) Botón Remover SubReceta
            if (btnCol.Name == "btnRemoveRecipeSubRecipe")
            {
                if (MessageBox.Show(
                        "¿Seguro quiere remover esta SubReceta?",
                        "Remover SubReceta",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) != DialogResult.Yes)
                {
                    return;
                }

                // 4) Leer el ID de forma segura
                var cell = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"];
                if (cell?.Value is not long idToRemove)
                    return;

                // 5) Deferir la eliminación y el rebindeo al final del ciclo de eventos
                this.BeginInvoke((Action)(() =>
                {
                    SubRecipes.RemoveAll(x => x.SubRecipeId == idToRemove);
                    GvSubRecipesDataBind();
                    RecalculateCosts();
                }));
            }
            // 6) Botón Ver SubReceta
            else if (btnCol.Name == "btnViewRecipeSubRecipeView")
            {
                var cell = gvSubRecipe.Rows[e.RowIndex].Cells["SubRecipeId"];
                if (cell?.Value is not long idToView)
                    return;

                try
                {
                    var viewForm = new ViewRecipe((int)idToView, RecipesBLL);
                    viewForm.Show();
                }
                catch (Exception ex)
                {
                    ShowError("Error abriendo SubReceta", ex);
                }
            }
        }

        // Método auxiliar para mostrar excepción con detalle
        private void ShowError(string title, Exception ex)
        {
            // Puedes cambiar Debug.WriteLine por tu logger favorito
            Debug.WriteLine($"[{title}] {ex.GetType().Name}: {ex.Message}");
            Debug.WriteLine(ex.StackTrace);

            MessageBox.Show(
                $"{title}:\n\n{ex.GetType().Name}\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
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
