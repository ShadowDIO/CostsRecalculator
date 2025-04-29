using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Recipes
{
    public partial class SelectRecipeIngredient : Form
    {
        public delegate void IngredientSelected(object sender, IngredientSelectedEventArgs e);
        public event IngredientSelected OnIngredientSelected;

        private readonly List<int> IngredientsAlreadyUsed;
        private List<IngredientDTO> Ingredients;
        private readonly IIngredientsBLL IngredientsBLL;

        public SelectRecipeIngredient(IEnumerable<int> ingredientsAlreadyUsed, IIngredientsBLL ingredientsBLL)
        {
            IngredientsAlreadyUsed = ingredientsAlreadyUsed.ToList();
            IngredientsBLL = ingredientsBLL;

            InitializeComponent();

            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            FetchIngredientsDataSource();
            CbIngredientNameDataBind();
        }

        private void FetchIngredientsDataSource()
        {
            var available = IngredientsBLL
                .GetAllIngredients()
                .Where(p => !IngredientsAlreadyUsed.Contains((int)p.Id));
            Ingredients = available.ToList();
        }

        private void CbIngredientNameDataBind()
        {
            var list = Ingredients
                .Select(p => new { p.Id, p.IngredientName })
                .ToList();

            cbIngredientName.DataSource = list;
            cbIngredientName.Update();

            cbIngredientName.AutoCompleteCustomSource
                .AddRange(list.Select(p => p.IngredientName).ToArray());
            cbIngredientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CbIngredientName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbIngredientName.SelectedValue == null) return;

            var dto = Ingredients
                .First(p => (int)p.Id == Convert.ToInt32(cbIngredientName.SelectedValue));

            txtUnits.Text = dto.UnitName;
            txtProvider.Text = dto.Provider;

            RecalculateValues();
        }

        private void TxtAmount_ValueChanged(object sender, EventArgs e) => RecalculateValues();
        private void TxtEfficiency_ValueChanged(object sender, EventArgs e) => RecalculateValues();

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (!ValidateUI()) return;

            var dto = Ingredients
                .First(p => p.Id == (long)cbIngredientName.SelectedValue);

            var ri = new RecipeIngredient
            {
                IngredientId = dto.Id,
                Ingredient = new Ingredient
                {
                    Id = dto.Id,
                    IngredientName = dto.IngredientName,
                    Cost = dto.Cost,
                    AmountSoldBy = dto.AmountSoldBy,
                    Efficiency = dto.Efficiency,
                    UnitId = dto.UnitId,
                    Provider = dto.Provider
                },
                Quantity = Convert.ToDouble(txtAmount.Value),
                Efficiency = Convert.ToDouble(txtEfficiency.Value / 100)
            };

            OnIngredientSelected?.Invoke(this, new IngredientSelectedEventArgs(ri));
            Close();
        }

        private bool ValidateUI()
        {
            if (cbIngredientName.SelectedValue == null)
            {
                MessageBox.Show(
                    "Debe seleccionar un ingrediente antes de continuar.",
                    "Campo requerido.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void RecalculateValues()
        {
            if (cbIngredientName.SelectedValue == null) return;

            var dto = Ingredients
                .First(p => (int)p.Id == Convert.ToInt32(cbIngredientName.SelectedValue));

            txtCalculatedEfficiency.Text =
                (txtAmount.Value * (txtEfficiency.Value / 100)).ToString();

            txtCost.Text = $"" +
                ((dto.Cost / dto.AmountSoldBy) * (double)txtAmount.Value)
                .ToString("C2");
        }

        /// <summary>
        /// Recorre recursivamente todos los controles hijos y suscribe
        /// Enter y MouseClick para hacer SelectAll() en TextBoxBase y NumericUpDown.
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
