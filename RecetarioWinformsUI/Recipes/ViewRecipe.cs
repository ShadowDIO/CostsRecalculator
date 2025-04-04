using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Helpers;
using System.Data;

namespace RecetarioWinformsUI.Recipes
{
    public partial class ViewRecipe : Form
    {
        private RecipeDTO? SelectedRecipe { get; set; }
        private RecipeRecalculateParametersDTO? RecalculateParameters { get; set; } = null;
        private readonly IRecipesBLL RecipesBLL;

        public ViewRecipe(int recipeId, IRecipesBLL recipesBLL)
        {
            InitializeComponent();
            RecipesBLL = recipesBLL;
            CbMarginDataBind();
            LoadSelectedRecipeDataSource(recipeId);
            LoadRecipeUI();
        }

        public ViewRecipe(int recipeId, RecipeRecalculateParametersDTO recalculateParameters, IRecipesBLL recipesBLL)
        {
            InitializeComponent();
            RecalculateParameters = recalculateParameters;
            RecipesBLL = recipesBLL;
            CbMarginDataBind();
            LoadSelectedRecipeDataSource(recipeId);
            LoadRecalculateFieldParameters(recalculateParameters);
            LoadRecipeUI();
        }

        private void LoadSelectedRecipeDataSource(int recipeId)
        {
            if (RecalculateParameters == null)
            {
                SelectedRecipe = RecipesBLL.GetRecipe(recipeId, true);
            }
            else
            {
                SelectedRecipe = RecipesBLL.RecalculateRecipe(recipeId, RecalculateParameters);
            }
        }

        private void LoadRecipeUI()
        {
            lblRecipeName.Text = $"{SelectedRecipe.RecipeName} para {SelectedRecipe.AmountProduced} {SelectedRecipe.UnitName}";
            txtRecipeName.Text = SelectedRecipe.RecipeName;
            txtAmount.Value = Convert.ToDecimal(SelectedRecipe.AmountProduced);
            txtUnits.Text = SelectedRecipe.UnitName;
            txtCost.Text = SelectedRecipe.Cost.ToString("C2");
            txtEfficiency.Value = Convert.ToDecimal(SelectedRecipe.Efficiency * 100);

            gvRecipeIngredients.DataSource = SelectedRecipe.Ingredients.Select(p => new
            {
                Id = p.Ingredient.Id,
                IngredientName = StringHelper.TrimLongName(p.Ingredient.IngredientName),
                IngredientQuantity = p.Quantity.ToString("F2"),
                IngredientUnit = p.Ingredient.UnitName,
                IngredientEfficiency = p.Efficiency.ToString("P"),
                IngredientCost = p.Cost.ToString("C2")
            }).ToList();
            gvRecipeIngredients.Update();

            txtIngredientCosts.Text = SelectedRecipe.Ingredients.Sum(p => p.Cost).ToString("C2");

            gvSubRecipes.DataSource = SelectedRecipe.SubRecipes.Select(p => new
            {
                SubRecipeId = p.SubRecipe?.Id,
                SubRecipeName = p.SubRecipe?.RecipeName,
                SubRecipeQuantity = p.Quantity.ToString("F2"),
                SubRecipeUnit = p.SubRecipe?.UnitName,
                SubRecipeEfficiency = p.Efficiency.ToString("P"),
                SubRecipeCost = p.Cost.ToString("C2")
            }).ToList();
            gvSubRecipes.Update();

            txtSubRecipesCost.Text = SelectedRecipe.SubRecipes.Sum(p => p.Cost).ToString("C2");

            CalculateUtilityMargin();
        }

        private void LoadRecalculateFieldParameters(RecipeRecalculateParametersDTO recalculateParameters)
        {
            switch (recalculateParameters.RecalculateType)
            {
                case RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight:
                    rbRecalculateByWeight.Checked = true;
                    break;
                case RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost:
                default:
                    rbRecalculateByCost.Checked = true;
                    break;
            }

            switch (recalculateParameters.RecalculateOverField)
            {
                case RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Ingredient:
                    rbRecalculateByIngredient.Checked = true;
                    break;
                case RecetarioBackEnd.Enums.RecalculateOverFieldEnum.SubRecipe:
                    rbRecalculateBySubRecipe.Checked = true;
                    break;
                case RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Total:
                default:
                    rbRecalculateByRecipeTotal.Checked = true;
                    break;
            }

            txtRecalculateValue.Value = Convert.ToDecimal(recalculateParameters.RecalculateValue);
            cbRecalculateField.SelectedValue = recalculateParameters.RecalculateFieldId;
        }

        private void CbMarginDataBind()
        {
            var valuesCollection = new Dictionary<int, string>();
            for (var i = 28; i < 33; i++)
            {
                valuesCollection.Add(i, (i / 100d).ToString("P0"));
            }

            cbMarginEarnings.DisplayMember = "Value";
            cbMarginEarnings.ValueMember = "Key";
            cbMarginEarnings.DataSource = new BindingSource(valuesCollection, string.Empty);
            cbMarginEarnings.Update();
        }

        private void CbRecalculateFieldDataBindIngredients()
        {
            var availableFields = SelectedRecipe.Ingredients.Select(p =>
            new
            {
                Id = p.Ingredient.Id,
                Value = p.Ingredient.IngredientName
            }).ToList();

            cbRecalculateField.DataSource = availableFields;
            cbRecalculateField.Update();
        }

        private void CbRecalculateFieldDataBindSubRecipes()
        {
            var availableFields = SelectedRecipe.SubRecipes
                .Where(p => p.SubRecipe != null && !string.IsNullOrEmpty(p.SubRecipe?.RecipeName))
                .Select(p =>
                new
                {
                    Id = p.SubRecipe.Id,
                    Value = p.SubRecipe.RecipeName
                }).ToList();

            cbRecalculateField.DataSource = availableFields;
            cbRecalculateField.Update();
        }

        private void CalculateUtilityMargin()
        {
            if (cbMarginEarnings.SelectedValue == null || string.IsNullOrEmpty(txtCost.Text))
                return;

            var recipeMarginPercentage = ((int)cbMarginEarnings.SelectedValue) / 100f;
            var utilityMargin = Single.Parse(txtCost.Text, System.Globalization.NumberStyles.Currency) / recipeMarginPercentage;

            txtSuggestedPrice.Text = utilityMargin.ToString("C2");
        }

        private void BtnRecalculateRecipe_Click(object sender, EventArgs e)
        {
            var recalculateParameters = new RecipeRecalculateParametersDTO
            {
                RecalculateValue = Convert.ToDouble(txtRecalculateValue.Value),
                RecalculateType = rbRecalculateByCost.Checked ? RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost : RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight,
                RecalculateOverField = rbRecalculateByRecipeTotal.Checked
                    ? RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Total
                    : (rbRecalculateByIngredient.Checked ? RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Ingredient : RecetarioBackEnd.Enums.RecalculateOverFieldEnum.SubRecipe),
                RecalculateFieldId = cbRecalculateField.SelectedValue == null ? -1 : (int)cbRecalculateField.SelectedValue
            };

            var viewSubRecipeForm = new ViewRecipe((int)SelectedRecipe.Id, recalculateParameters, RecipesBLL)
            {
                MdiParent = this.MdiParent
            };
            viewSubRecipeForm.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbMarginEarnings_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateUtilityMargin();
        }

        private void GvSubRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvSubRecipes.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (((DataGridViewButtonColumn)gvSubRecipes.Columns[e.ColumnIndex]).Name == "btnViewRecipeSubRecipeView")
                {
                    var recipeId = gvSubRecipes.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
                    if (recipeId.HasValue)
                    {
                        OpenSubRecipeView((int)recipeId.Value);
                    }
                }
            }
        }

        private void GvSubRecipes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var recipeId = gvSubRecipes.Rows[e.RowIndex].Cells["SubRecipeId"].Value as long?;
            if (recipeId.HasValue)
            {
                OpenSubRecipeView((int)recipeId.Value);
            }
        }

        private void OpenSubRecipeView(int subRecipeId)
        {
            var viewSubRecipeForm = new ViewRecipe(subRecipeId, RecipesBLL)
            {
                MdiParent = this.MdiParent
            };
            viewSubRecipeForm.Show();
        }

        private void RbFiltersChanged(object sender, EventArgs e)
        {
            cbRecalculateField.Enabled = !rbRecalculateByRecipeTotal.Checked;

            if (rbRecalculateByCost.Checked)
            {
                if (rbRecalculateByRecipeTotal.Checked)
                {
                    label9.Text = "Costo Receta($)";
                    cbRecalculateField.DataSource = null;
                }
                else if (rbRecalculateByIngredient.Checked)
                {
                    label9.Text = "Costo Ingrediente($)";
                    label1.Text = "Ingrediente";
                    CbRecalculateFieldDataBindIngredients();
                }
                else if (rbRecalculateBySubRecipe.Checked)
                {
                    label9.Text = "Costo Subreceta($)";
                    label1.Text = "SubReceta";
                    CbRecalculateFieldDataBindSubRecipes();
                }
            }
            else if(rbRecalculateByWeight.Checked)
            {
                if(rbRecalculateByRecipeTotal.Checked)
                {
                    label9.Text = $"Peso de Receta({SelectedRecipe.UnitName})";
                    cbRecalculateField.DataSource = null;
                }
                else if(rbRecalculateByIngredient.Checked)
                {
                    var selectedIngredient = cbRecalculateField.SelectedValue != null ? $"({SelectedRecipe?.Ingredients.First(p => p.Id == (long)cbRecalculateField.SelectedValue).Ingredient.UnitName})" : string.Empty;

                    label9.Text = $"Peso de Ingrediente{selectedIngredient}";
                    label1.Text = "Ingrediente";
                    CbRecalculateFieldDataBindIngredients();
                }
                else if(rbRecalculateBySubRecipe.Checked)
                {
                    var selectedSubRecipe = cbRecalculateField.SelectedValue != null ? $"({SelectedRecipe?.SubRecipes.FirstOrDefault(p => p.Id == (long)cbRecalculateField.SelectedValue)?.SubRecipe?.UnitName})" : string.Empty;

                    label9.Text = $"Peso de Subreceta{selectedSubRecipe}";
                    label1.Text = "SubReceta";
                    CbRecalculateFieldDataBindSubRecipes();
                }
            }
        }
    }
}
