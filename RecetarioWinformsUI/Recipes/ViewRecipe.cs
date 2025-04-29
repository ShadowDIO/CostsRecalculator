using System.Data;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Helpers;

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
            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            RecipesBLL = recipesBLL;
            CbMarginDataBind();
            LoadSelectedRecipeDataSource(recipeId);
            LoadRecipeUI();
        }

        public ViewRecipe(int recipeId, RecipeRecalculateParametersDTO recalculateParameters, IRecipesBLL recipesBLL)
        {
            InitializeComponent();
            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

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
                SelectedRecipe = RecipesBLL.GetRecipe(recipeId);
            else
                SelectedRecipe = RecipesBLL.RecalculateRecipe(recipeId, RecalculateParameters);
        }

        private void LoadRecipeUI()
        {
            if (SelectedRecipe == null) return;

            lblRecipeName.Text = $"{SelectedRecipe.RecipeName} para {SelectedRecipe.AmountProduced} {SelectedRecipe.UnitName}";
            txtRecipeName.Text = SelectedRecipe.RecipeName;
            txtAmount.Value = Convert.ToDecimal(SelectedRecipe.AmountProduced);
            txtUnits.Text = SelectedRecipe.UnitName;
            txtCost.Text = SelectedRecipe.Cost.ToString("C2");
            txtEfficiency.Value = Convert.ToDecimal(SelectedRecipe.Efficiency);

            gvRecipeIngredients.DataSource = SelectedRecipe.Ingredients.Select(p => new
            {
                Id = p.Ingredient.Id,
                IngredientName = StringHelper.TrimLongName(p.Ingredient.IngredientName),
                IngredientQuantity = p.Quantity,
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
                SubRecipeQuantity = p.Quantity,
                SubRecipeUnit = p.SubRecipe?.UnitName,
                SubRecipeEfficiency = p.Efficiency.ToString("P"),
                SubRecipeCost = p.Cost.ToString("C2")
            }).ToList();
            gvSubRecipes.Update();

            txtSubRecipesCost.Text = SelectedRecipe.SubRecipes.Sum(p => p.Cost).ToString("C2");

            CalculateUtilityMargin();
        }

        private void LoadRecalculateFieldParameters(RecipeRecalculateParametersDTO recalc)
        {
            switch (recalc.RecalculateType)
            {
                case RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight:
                    rbRecalculateByWeight.Checked = true; break;
                case RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost:
                default:
                    rbRecalculateByCost.Checked = true; break;
            }

            switch (recalc.RecalculateOverField)
            {
                case RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Ingredient:
                    rbRecalculateByIngredient.Checked = true; break;
                case RecetarioBackEnd.Enums.RecalculateOverFieldEnum.SubRecipe:
                    rbRecalculateBySubRecipe.Checked = true; break;
                case RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Total:
                default:
                    rbRecalculateByRecipeTotal.Checked = true; break;
            }

            txtRecalculateValue.Value = Convert.ToDecimal(recalc.RecalculateValue);
            cbRecalculateField.SelectedValue = recalc.RecalculateFieldId;
        }

        private void CbMarginDataBind()
        {
            var values = new Dictionary<int, string>();
            for (int i = 28; i < 33; i++)
                values[i] = (i / 100d).ToString("P");

            cbMarginEarnings.DisplayMember = "Value";
            cbMarginEarnings.ValueMember = "Key";
            cbMarginEarnings.DataSource = new BindingSource(values, null);
            cbMarginEarnings.Update();
        }

        private void CalculateUtilityMargin()
        {
            if (cbMarginEarnings.SelectedValue == null || string.IsNullOrEmpty(txtCost.Text))
                return;

            float pct = ((int)cbMarginEarnings.SelectedValue) / 100f;
            float cost = float.Parse(txtCost.Text, System.Globalization.NumberStyles.Currency);
            txtSuggestedPrice.Text = (cost / pct).ToString("C2");
        }

        private void RbRecalculateBy_CheckedChanged(object sender, EventArgs e)
        {
            cbRecalculateField.Enabled = !rbRecalculateByRecipeTotal.Checked;

            if (rbRecalculateByIngredient.Checked)
                CbRecalculateFieldDataBindIngredients();
            else if (rbRecalculateBySubRecipe.Checked)
                CbRecalculateFieldDataBindSubRecipes();
            else
                cbRecalculateField.DataSource = null;
        }

        private void CbRecalculateFieldDataBindIngredients()
        {
            cbRecalculateField.DataSource = SelectedRecipe?.Ingredients
                .Select(p => new { Id = p.Ingredient.Id, Value = p.Ingredient.IngredientName })
                .ToList();
            cbRecalculateField.Update();
        }

        private void CbRecalculateFieldDataBindSubRecipes()
        {
            cbRecalculateField.DataSource = SelectedRecipe?.SubRecipes
                .Where(p => p.SubRecipe != null && !string.IsNullOrEmpty(p.SubRecipe.RecipeName))
                .Select(p => new { Id = p.SubRecipe.Id, Value = p.SubRecipe.RecipeName })
                .ToList();
            cbRecalculateField.Update();
        }

        private void BtnRecalculateRecipe_Click(object sender, EventArgs e)
        {
            if (SelectedRecipe == null) return;

            var recalc = new RecipeRecalculateParametersDTO
            {
                RecalculateValue = Convert.ToDouble(txtRecalculateValue.Value),
                RecalculateType = rbRecalculateByCost.Checked
                                      ? RecetarioBackEnd.Enums.RecalculateTypeEnum.Cost
                                      : RecetarioBackEnd.Enums.RecalculateTypeEnum.Weight,
                RecalculateOverField = rbRecalculateByRecipeTotal.Checked
                                      ? RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Total
                                      : rbRecalculateByIngredient.Checked
                                        ? RecetarioBackEnd.Enums.RecalculateOverFieldEnum.Ingredient
                                        : RecetarioBackEnd.Enums.RecalculateOverFieldEnum.SubRecipe,
                RecalculateFieldId = cbRecalculateField.SelectedValue == null
                                      ? -1
                                      : (int)cbRecalculateField.SelectedValue
            };

            var form = new ViewRecipe((int)SelectedRecipe.Id, recalc, RecipesBLL)
            {
                MdiParent = this.MdiParent
            };
            form.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();
        private void CbMarginEarnings_SelectedIndexChanged(object sender, EventArgs e) => CalculateUtilityMargin();

        private void GvSubRecipes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (gvSubRecipes.Columns[e.ColumnIndex] is DataGridViewButtonColumn btn
                && btn.Name == "btnViewRecipeSubRecipeView")
            {
                var id = gvSubRecipes.Rows[e.RowIndex]
                                   .Cells["SubRecipeId"].Value as long?;
                if (id.HasValue) OpenSubRecipeView((int)id.Value);
            }
        }

        private void GvSubRecipes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var id = gvSubRecipes.Rows[e.RowIndex]
                               .Cells["SubRecipeId"].Value as long?;
            if (id.HasValue) OpenSubRecipeView((int)id.Value);
        }

        private void OpenSubRecipeView(int subRecipeId)
        {
            var frm = new ViewRecipe(subRecipeId, RecipesBLL)
            {
                MdiParent = this.MdiParent
            };
            frm.Show();
        }

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
