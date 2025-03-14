using RecetarioBackEnd.BLL;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;
using System.Data;
using static RecetarioWinformsUI.Recipes.SelectRecipeIngredient;

namespace RecetarioWinformsUI.Recipes
{
    public partial class UpdateRecipe : Form
    {
        public RecipeDTO Recipe { get; private set; }

        private List<RecipeIngredientDTO> Ingredients = new();

        private List<RecipeSubRecipeDTO> SubRecipes = new();

        private readonly IRecipesBLL RecipesBLL;
        private readonly IUnitsBLL UnitsBLL;
        private readonly IIngredientsBLL IngredientsBLL;

        public UpdateRecipe(int recipeId, IRecipesBLL recipesBLL, IUnitsBLL unitsBLL, IIngredientsBLL ingredientsBLL)
        {
            InitializeComponent();
            RecipesBLL = recipesBLL;
            UnitsBLL = unitsBLL;
            IngredientsBLL = ingredientsBLL;

            CbUnitsDataBind();
            LoadDataSource(recipeId);
            LoadRecipeGeneralData();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
            RecalculateCosts();

            GlobalUIEvents.Instance.OnUnitAdded += OnUnitAdded;
            GlobalUIEvents.Instance.OnUnitUpdated += OnUnitUpdated;
            GlobalUIEvents.Instance.OnIngredientUpdated += OnIngredientUpdated;
            GlobalUIEvents.Instance.OnRecipeUpdated += OnRecipeUpdated;
            IngredientsBLL = ingredientsBLL;
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

        #endregion

        #region Private Methods

        private void LoadDataSource(int recipeId)
        {
            Recipe = RecipesBLL.GetRecipe(recipeId, includeUnits: true, includeIngredientsAndSubRecipes: true);
            Ingredients = Recipe.Ingredients.ToList();
            SubRecipes = Recipe.SubRecipes.ToList();
        }

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL.GetAllUnits()
                .Select(p => new { p.Id, p.Abbreviation })
                .ToList();
            cbUnits.Update();
        }

        private void LoadRecipeGeneralData()
        {
            txtRecipeName.Text = Recipe.RecipeName;
            txtAmount.Value = Convert.ToDecimal(Recipe.AmountProduced);
            cbUnits.SelectedValue = Recipe.UnitId;
            txtEfficiency.Value = Convert.ToDecimal(Recipe.Efficiency * 100);
        }

        private void GvIngredientsDataBind()
        {
            gvRecipeIngredients.DataSource = Ingredients.Select(p => new
            {
                IngredientId = p.Ingredient.Id,
                IngredientName = p.Ingredient.IngredientName,
                IngredientQuantity = p.Quantity,
                IngredientUnit = p.Ingredient.UnitName,
                IngredientEfficiency = p.Efficiency.ToString("P"),
                IngredientCost = ((p.Ingredient.Cost / p.Ingredient.AmountSoldBy) * p.Quantity).ToString("C2")
            }).ToList();
            gvRecipeIngredients.Refresh();
        }

        private void GvSubRecipesDataBind()
        {
            gvSubRecipe.DataSource = SubRecipes.Select(p => new
            {
                SubRecipeId = p.SubRecipe.Id,
                SubRecipeName = p.SubRecipe.RecipeName,
                SubRecipeQuantity = p.Quantity,
                SubRecipeUnit = p.SubRecipe.UnitName,
                SubRecipeEfficiency = p.Efficiency.ToString("P"),
                SubRecipeCost = RecipesBLL.CalculateRecipeCosts(p.SubRecipe).ToString("C2")
            }).ToList();
            gvSubRecipe.Refresh();
        }

        private void RecalculateCosts()
        {
            var ingredientsCost = Ingredients.Sum(q => (q.Ingredient.Cost / q.Ingredient.AmountSoldBy) * q.Quantity);
            txtIngredientCosts.Text = ingredientsCost.ToString("C2");

            var subRecipesCost = SubRecipes.Sum(q => RecipesBLL.CalculateRecipeCosts(q.SubRecipe));
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

        private void BtnUpdateRecipe_Click(object sender, EventArgs e)
        {
            if (!ValidateRecipe())
            {
                return;
            }

            // Actualizar la información principal de la receta
            Recipe.RecipeName = txtRecipeName.Text.Trim();
            Recipe.Efficiency = (float)(txtEfficiency.Value / 100); // Conversión a float
            Recipe.AmountProduced = (float)txtAmount.Value; // Conversión a float
            Recipe.UnitId = Convert.ToInt32(cbUnits.SelectedValue);

            // Actualiza la receta principal
            RecipesBLL.UpdateRecipe(Recipe);

            // Obtener las relaciones actuales de la base de datos
            var existingIngredients = RecipesBLL.GetRecipeIngredients((int)Recipe.Id);
            var existingSubRecipes = RecipesBLL.GetRecipeSubRecipes((int)Recipe.Id);

            // Identificar ingredientes a eliminar, actualizar o agregar
            var ingredientsToDelete = existingIngredients.Where(e => !Ingredients.Any(i => i.Ingredient.Id == e.Ingredient.Id)).ToList();
            var ingredientsToAdd = Ingredients.Where(i => !existingIngredients.Any(e => e.Ingredient.Id == i.Ingredient.Id)).ToList();
            var ingredientsToUpdate = Ingredients.Where(i => existingIngredients.Any(e => e.Ingredient.Id == i.Ingredient.Id)).ToList();

            // Eliminar ingredientes que ya no existen
            ingredientsToDelete.ForEach(ingredient => RecipesBLL.DeleteRecipeIngredient((int)ingredient.IngredientId));

            // Actualizar los ingredientes existentes
            //ingredientsToUpdate.ForEach(ingredient =>
            //{
            //    ingredient.Id = ingredient.Id;
            //    ingredient.RecipeId = Recipe.Id;
            //    ingredient.IngredientId = ingredient.Ingredient.Id;
            //    RecipesBLL.UpdateRecipeIngredient(ingredient);
            //});

            // Insertar los nuevos ingredientes
            ingredientsToAdd.ForEach(ingredient =>
            {
                ingredient.RecipeId = Recipe.Id;
                RecipesBLL.CreateRecipeIngredient(ingredient);
            });

            // Identificar subrecetas a eliminar, actualizar o agregar
            var subRecipesToDelete = existingSubRecipes.Where(e => !SubRecipes.Any(s => s.SubRecipe.Id == e.SubRecipe.Id)).ToList();
            var subRecipesToAdd = SubRecipes.Where(s => !existingSubRecipes.Any(e => e.SubRecipe.Id == s.SubRecipe.Id)).ToList();
            var subRecipesToUpdate = SubRecipes.Where(s => existingSubRecipes.Any(e => e.SubRecipe.Id == s.SubRecipe.Id)).ToList();

            // Eliminar subrecetas que ya no existen
            subRecipesToDelete.ForEach(subRecipe => RecipesBLL.DeleteRecipeSubRecipe((int)subRecipe.SubRecipeId));

            // Actualizar las subrecetas existentes
            //subRecipesToUpdate.ForEach(subRecipe =>
            //{
            //    subRecipe.RecipeId = Recipe.Id;
            //    subRecipe.SubRecipeId = subRecipe.SubRecipe.Id;
            //    RecipesBLL.UpdateRecipeSubRecipe(subRecipe);
            //});

            // Insertar las nuevas subrecetas
            subRecipesToAdd.ForEach(subRecipe =>
            {
                subRecipe.RecipeId = Recipe.Id;
                RecipesBLL.CreateRecipeSubRecipe(subRecipe);
            });

            // Emitir el evento de que la receta ha sido agregada
            GlobalUIEvents.Instance.DispatchOnRecipeAdded(this, new EventArgs());
            MessageBox.Show("Receta actualizada exitosamente.", "Recetas.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            var frmSelectRecipeIngredient = new SelectRecipeIngredient(
                Ingredients.Select(p => (int)p.Ingredient.Id), // Pasar los IDs de ingredientes ya seleccionados
                IngredientsBLL // Pasar el BLL de ingredientes
            );

            frmSelectRecipeIngredient.OnIngredientSelected += OnIngredientSelected;
            frmSelectRecipeIngredient.ShowDialog();
        }

        private void OnIngredientSelected(object sender, IngredientSelectedEventArgs e)
        {
            // Verificar si el ingrediente ya existe en la lista antes de agregarlo
            if (Ingredients.Any(ingredient => ingredient.Ingredient.Id == e.RecipeIngredientSelected.Ingredient.Id))
            {
                MessageBox.Show("Este ingrediente ya ha sido agregado.", "Ingrediente duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Convertir el ingrediente seleccionado a RecipeIngredientDTO
            var selectedIngredientDto = MapToDTO(e.RecipeIngredientSelected);

            selectedIngredientDto.RecipeId = Recipe.Id; // Asignar el ID de la receta actual

            Ingredients.Add(selectedIngredientDto);

            GvIngredientsDataBind();
            RecalculateCosts();
        }


        private RecipeIngredientDTO MapToDTO(RecipeIngredient ingredient)
        {
            return new RecipeIngredientDTO
            {
                Id = (int)ingredient.Id,
                RecipeId = ingredient.RecipeId,
                Ingredient = new IngredientDTO
                {
                    Id = ingredient.Ingredient.Id,
                    IngredientName = ingredient.Ingredient.IngredientName,
                    UnitName = ingredient.Ingredient.Unit?.Abbreviation ?? "Unidad no encontrada",
                    Cost = ingredient.Ingredient.Cost,
                    AmountSoldBy = ingredient.Ingredient.AmountSoldBy
                },
                Quantity = ingredient.Quantity,
                Efficiency = ingredient.Efficiency
            };
        }








    }
}
