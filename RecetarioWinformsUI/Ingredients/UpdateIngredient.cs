using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Ingredients
{
    public partial class UpdateIngredient : Form
    {
        private IngredientDTO? Ingredient { get; set; }
        private readonly IIngredientsBLL IngredientsBLL;
        private readonly IUnitsBLL UnitsBLL;

        public UpdateIngredient(int ingredientId, IIngredientsBLL ingredientsBLL, IUnitsBLL unitsBLL)
        {
            InitializeComponent();

            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            IngredientsBLL = ingredientsBLL;
            UnitsBLL = unitsBLL;

            LoadIngredient(ingredientId);
            CbUnitsDataBind();
            LoadUI();

            GlobalUIEvents.Instance.OnUnitAdded += OnUnitAdded;
            GlobalUIEvents.Instance.OnUnitUpdated += OnUnitUpdated;
        }

        private void OnUnitAdded(object sender, EventArgs e)
        {
            CbUnitsDataBind();
        }

        private void OnUnitUpdated(object sender, EventArgs e)
        {
            CbUnitsDataBind();
        }

        private void LoadIngredient(int ingredientId)
        {
            Ingredient = IngredientsBLL.GetIngredientById(ingredientId)
                         ?? throw new KeyNotFoundException($"Ingrediente con ID {ingredientId} no encontrado.");
        }

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL.GetAllUnits()
                                 .Select(p => new { p.Id, p.Abbreviation })
                                 .ToList();
            cbUnits.Update();
        }

        private void LoadUI()
        {
            txtIngredientName.Text = Ingredient.IngredientName;
            txtCost.Value = Convert.ToDecimal(Ingredient.Cost);
            txtAmountSoldBy.Value = Convert.ToDecimal(Ingredient.AmountSoldBy);
            txtEfficiency.Value = Convert.ToDecimal(Ingredient.Efficiency * 100);
            cbUnits.SelectedValue = Ingredient.UnitId;
            txtProvider.Text = Ingredient.Provider;
        }

        private bool ValidateUI()
        {
            if (string.IsNullOrWhiteSpace(txtIngredientName.Text))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Campo requerido.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtProvider.Text))
            {
                MessageBox.Show("El campo Proveedor no puede estar vacío.", "Campo requerido.",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void SaveIngredient()
        {
            Ingredient.IngredientName = txtIngredientName.Text.Trim();
            Ingredient.Cost = Convert.ToDouble(txtCost.Value);
            Ingredient.AmountSoldBy = Convert.ToDouble(txtAmountSoldBy.Value);
            Ingredient.Efficiency = Convert.ToDouble(txtEfficiency.Value / 100);
            Ingredient.UnitId = (long)cbUnits.SelectedValue;
            Ingredient.Provider = txtProvider.Text.Trim();

            IngredientsBLL.UpdateIngredient(Ingredient);
            GlobalUIEvents.Instance.DispatchOnIngredientAdded(this, EventArgs.Empty);
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            SaveIngredient();
            MessageBox.Show("Ingrediente actualizado exitosamente.", "Ingrediente.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// Recorre recursivamente controles y suscribe Enter y MouseClick para SelectAll().
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