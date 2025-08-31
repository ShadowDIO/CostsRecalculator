using System.ComponentModel;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Recipes
{
    public partial class UpdateRecipe : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RecipeDTO? Recipe { get; private set; }

        private List<RecipeIngredientDTO> Ingredients = new();
        private List<RecipeSubRecipeDTO> SubRecipes = new();

        private readonly IRecipesBLL RecipesBLL;
        private readonly IUnitsBLL UnitsBLL;
        private readonly IIngredientsBLL IngredientsBLL;
        private readonly IRecipeIngredientsBLL RecipeIngredientsBLL;
        private readonly IRecipeSubRecipesBLL RecipeSubRecipesBLL;

        public UpdateRecipe(
            int recipeId,
            IRecipesBLL recipesBLL,
            IUnitsBLL unitsBLL,
            IIngredientsBLL ingredientsBLL,
            IRecipeIngredientsBLL recipeIngredientsBLL,
            IRecipeSubRecipesBLL recipeSubRecipesBLL
        )
        {
            InitializeComponent();
            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            RecipesBLL = recipesBLL;
            UnitsBLL = unitsBLL;
            IngredientsBLL = ingredientsBLL;
            RecipeIngredientsBLL = recipeIngredientsBLL;
            RecipeSubRecipesBLL = recipeSubRecipesBLL;

            CbUnitsDataBind();
            LoadDataSource(recipeId);
            LoadRecipeGeneralData();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
            RecalculateCosts();

            GlobalUIEvents.Instance.OnUnitAdded += OnUnitChanged;
            GlobalUIEvents.Instance.OnUnitUpdated += OnUnitChanged;
            GlobalUIEvents.Instance.OnIngredientUpdated += OnIngredientOrRecipeChanged;
            GlobalUIEvents.Instance.OnRecipeUpdated += OnIngredientOrRecipeChanged;
        }

        #region Eventos Globales

        private void OnUnitChanged(object sender, EventArgs e)
        {
            CbUnitsDataBind();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
        }

        private void OnIngredientOrRecipeChanged(object sender, EventArgs e)
        {
            CbUnitsDataBind();
            GvIngredientsDataBind();
            GvSubRecipesDataBind();
            RecalculateCosts();
        }

        #endregion

        #region Carga y Bindings

        private void LoadDataSource(int recipeId)
        {
            Recipe = RecipesBLL.GetRecipe(
                recipeId,
                includeUnits: true,
                includeIngredientsAndSubRecipes: true
            );
            Ingredients = Recipe?.Ingredients.ToList() ?? new();
            SubRecipes = Recipe?.SubRecipes.ToList() ?? new();
        }

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL
                .GetAllUnits()
                .Select(u => new { u.Id, u.Abbreviation })
                .ToList();
        }

        private void LoadRecipeGeneralData()
        {
            if (Recipe == null) return;
            txtRecipeName.Text = Recipe.RecipeName;
            txtAmount.Value = Convert.ToDecimal(Recipe.AmountProduced);
            cbUnits.SelectedValue = (long)Recipe.UnitId;
            txtEfficiency.Value = Convert.ToDecimal(Recipe.Efficiency * 100);
        }

        private void GvIngredientsDataBind()
        {
            gvRecipeIngredients.DataSource = Ingredients
                .Select(i => new
                {
                    RelationId = i.Id,
                    Id = i.Ingredient.Id,
                    IngredientName = i.Ingredient.IngredientName,
                    IngredientQuantity = i.Quantity,
                    IngredientUnit = i.Ingredient.UnitName,
                    IngredientEfficiency = i.Efficiency.ToString("P"),
                    IngredientCost = ((i.Ingredient.Cost / i.Ingredient.AmountSoldBy) * i.Quantity)
                                            .ToString("C2")
                })
                .ToList();

            if (gvRecipeIngredients.Columns["RelationId"] != null)
                gvRecipeIngredients.Columns["RelationId"].Visible = false;
            if (gvRecipeIngredients.Columns["Id"] != null)
                gvRecipeIngredients.Columns["Id"].Visible = false;

            gvRecipeIngredients.Refresh();
        }

        private void GvSubRecipesDataBind()
        {
            gvSubRecipe.DataSource = SubRecipes
                .Select(s => new
                {
                    RelationId = s.Id,
                    SubRecipeId = s.SubRecipeId,
                    SubRecipeName = s.SubRecipe.RecipeName,
                    SubRecipeQuantity = s.Quantity,
                    SubRecipeUnit = s.SubRecipe.UnitName,
                    SubRecipeEfficiency = s.Efficiency.ToString("P"),
                    SubRecipeCost = RecipesBLL.CalculateRecipeCosts(s.SubRecipe)
                                          .ToString("C2")
                })
                .ToList();

            if (gvSubRecipe.Columns["RelationId"] != null)
                gvSubRecipe.Columns["RelationId"].Visible = false;
            if (gvSubRecipe.Columns["SubRecipeId"] != null)
                gvSubRecipe.Columns["SubRecipeId"].Visible = false;

            gvSubRecipe.Refresh();
        }

        private void RecalculateCosts()
        {
            var ingrCost = Ingredients
                .Sum(i => (i.Ingredient.Cost / i.Ingredient.AmountSoldBy) * i.Quantity);
            txtIngredientCosts.Text = ingrCost.ToString("C2");

            var subCost = SubRecipes
                .Sum(s => RecipesBLL.CalculateRecipeCosts(s.SubRecipe));
            txtSubRecipesCost.Text = subCost.ToString("C2");

            txtCost.Text = $"{ingrCost + subCost:C2}";
        }

        private bool ValidateRecipe()
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("El nombre no puede ir vacío.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRecipeName.Focus();
                return false;
            }
            if (cbUnits.SelectedValue == null)
            {
                MessageBox.Show("Seleccione una unidad.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbUnits.Focus();
                return false;
            }
            if (!Ingredients.Any() && !SubRecipes.Any())
            {
                MessageBox.Show("Agregue al menos un ingrediente o subreceta.", "Campo requerido",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        #endregion

        #region Actualizar Receta

        private void BtnUpdateRecipe_Click(object sender, EventArgs e)
        {
            if (!ValidateRecipe() || Recipe == null) return;

            // 1) Actualiza datos principales de la receta
            Recipe.RecipeName = txtRecipeName.Text.Trim();
            Recipe.Efficiency = (float)(txtEfficiency.Value / 100m);
            Recipe.AmountProduced = (float)txtAmount.Value;
            Recipe.UnitId = Convert.ToInt32(cbUnits.SelectedValue);
            RecipesBLL.UpdateRecipe(Recipe);

            // 2) Sincroniza ingredientes
            // ——————————————————————————————————————————————————————————————————
            // Traigo lo que hay en BD
            var dbIngredients = RecipesBLL
                .GetRecipeIngredients((int)Recipe.Id)
                .ToList();

            // 2.a) Eliminar los que ya no están en la UI
            var toDeleteIngr = dbIngredients
                .Where(db => !Ingredients.Any(i => i.Ingredient.Id == db.Ingredient.Id))
                .ToList();
            toDeleteIngr.ForEach(x =>
                RecipeIngredientsBLL.DeleteRecipeIngredient(x.Id));

            // 2.b) Para cada ingrediente actual, o lo actualizo o lo creo
            foreach (var dto in Ingredients)
            {
                var existing = dbIngredients
                    .FirstOrDefault(db => db.Ingredient.Id == dto.Ingredient.Id);

                if (existing != null)
                {
                    // Ya existía → solo actualizo cantidad/eficiencia
                    existing.Quantity = dto.Quantity;
                    existing.Efficiency = dto.Efficiency;
                    RecipeIngredientsBLL.UpdateRecipeIngredient(existing);
                }
                else
                {
                    // Es nuevo → creo la relación
                    RecipeIngredientsBLL.CreateRecipeIngredient(new RecipeIngredientDTO
                    {
                        RecipeId = Recipe.Id,
                        Ingredient = new IngredientDTO { Id = dto.Ingredient.Id },
                        Quantity = dto.Quantity,
                        Efficiency = dto.Efficiency
                    });
                }
            }

            // 3) Sincroniza sub‐recetas (idéntico a ingredientes)
            // ——————————————————————————————————————————————————————————————————
            var dbSubs = RecipesBLL
                .GetRecipeSubRecipes((int)Recipe.Id)
                .ToList();

            // 3.a) Eliminar las subrecetas que ya no están
            var toDeleteSubs = dbSubs
                .Where(db => !SubRecipes.Any(s => s.SubRecipeId == db.SubRecipeId))
                .ToList();
            toDeleteSubs.ForEach(x =>
                RecipeSubRecipesBLL.DeleteRecipeSubRecipe(x.Id));

            // 3.b) Para cada subreceta actual, actualizo o creo
            foreach (var dto in SubRecipes)
            {
                var existing = dbSubs
                    .FirstOrDefault(db => db.SubRecipeId == dto.SubRecipeId);

                if (existing != null)
                {
                    existing.Quantity = dto.Quantity;
                    existing.Efficiency = dto.Efficiency;
                    RecipeSubRecipesBLL.UpdateRecipeSubRecipe(existing);
                }
                else
                {
                    RecipeSubRecipesBLL.CreateRecipeSubRecipe(new RecipeSubRecipeDTO
                    {
                        RecipeId = Recipe.Id,
                        SubRecipeId = dto.SubRecipeId,
                        Quantity = dto.Quantity,
                        Efficiency = dto.Efficiency
                    });
                }
            }

            // 4) Refresco UI y cierro
            GlobalUIEvents.Instance.DispatchOnRecipeUpdated(this, EventArgs.Empty);
            MessageBox.Show("Receta actualizada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        #endregion

        #region Agregar / Quitar Ingredientes

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            var frm = new SelectRecipeIngredient(
                Ingredients.Select(i => (int)i.Ingredient.Id),
                IngredientsBLL
            );
            frm.OnIngredientSelected += OnIngredientSelected;
            frm.ShowDialog();
        }

        private void OnIngredientSelected(object sender, IngredientSelectedEventArgs e)
        {
            if (Ingredients.Any(x => x.Ingredient.Id == e.RecipeIngredientSelected.Ingredient.Id))
            {
                MessageBox.Show("Este ingrediente ya ha sido agregado.", "Ingrediente duplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var newDto = MapToDTO(e.RecipeIngredientSelected);
            newDto.RecipeId = Recipe!.Id;

            Ingredients.Add(newDto);
            GvIngredientsDataBind();
            RecalculateCosts();
        }

        private RecipeIngredientDTO MapToDTO(RecipeIngredient ingredient)
        {
            var unitAbbrev = ingredient.Ingredient.UnitId > 0
                ? UnitsBLL.GetUnit((int)ingredient.Ingredient.UnitId)?.Abbreviation
                : null;

            return new RecipeIngredientDTO
            {
                Id = (int)ingredient.Id,
                RecipeId = ingredient.RecipeId,
                Ingredient = new IngredientDTO
                {
                    Id = ingredient.Ingredient.Id,
                    IngredientName = ingredient.Ingredient.IngredientName,
                    UnitName = unitAbbrev ?? "Unidad no encontrada",
                    Cost = ingredient.Ingredient.Cost,
                    AmountSoldBy = ingredient.Ingredient.AmountSoldBy
                },
                Quantity = ingredient.Quantity,
                Efficiency = ingredient.Efficiency
            };
        }

        private void GvRecipeIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0
                || gvRecipeIngredients.Columns[e.ColumnIndex] is not DataGridViewButtonColumn btn
                || btn.Name != "btnRemoveRecipeIngredient")
                return;

            if (MessageBox.Show("¿Remover este ingrediente?", "",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            var relationId = gvRecipeIngredients.Rows[e.RowIndex].Cells["RelationId"].Value;
            if (relationId is not int id) return;

            BeginInvoke((Action)(() =>
            {
                Ingredients.RemoveAll(x => x.Id == id);
                GvIngredientsDataBind();
                RecalculateCosts();
            }));
        }

        #endregion

        #region Agregar / Quitar SubRecetas

        private void btnAddSubRecipe_Click(object sender, EventArgs e)
        {
            var frm = new SelectRecipeSubRecipe(
                SubRecipes.Select(s => (int)s.SubRecipeId),
                RecipesBLL,
                UnitsBLL
            );
            frm.OnSubRecipeSelected += OnSubRecipeSelected;
            frm.ShowDialog();
        }

        private void OnSubRecipeSelected(object sender, SubRecipeSelectedEventArgs e)
        {
            var sel = e.SubRecipe;
            if (SubRecipes.Any(x => x.SubRecipeId == sel.SubRecipeId))
            {
                MessageBox.Show("Ya agregaste esa subreceta.", "Duplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SubRecipes.Add(new RecipeSubRecipeDTO
            {
                Id = (int)sel.Id,
                RecipeId = sel.RecipeId,
                SubRecipe = RecipesBLL.GetRecipe((int)sel.SubRecipeId)!,
                Quantity = sel.Quantity,
                Efficiency = sel.Efficiency
            });
            GvSubRecipesDataBind();
            RecalculateCosts();
        }

        #endregion

        /// <summary>
        /// Recorre recursivamente todos los controles hijos y suscribe Enter y MouseClick
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
