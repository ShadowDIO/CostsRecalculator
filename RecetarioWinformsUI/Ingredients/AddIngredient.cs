using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Ingredients
{
    public partial class AddIngredient : Form
    {
        private readonly IIngredientsBLL IngredientsBLL;
        private readonly IUnitsBLL UnitsBLL;

        public AddIngredient(IIngredientsBLL ingredientsBLL, IUnitsBLL unitsBLL)
        {
            InitializeComponent();

            // Habilita el comportamiento de SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            IngredientsBLL = ingredientsBLL;
            UnitsBLL = unitsBLL;

            CbUnitsDataBind();

            GlobalUIEvents.Instance.OnUnitAdded += OnUnitAdded;
            GlobalUIEvents.Instance.OnUnitUpdated += OnUnitUpdated;
        }

        private void AttachSelectAllBehavior(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // TextBox y RichTextBox
                if (c is TextBoxBase tb)
                {
                    tb.Enter += (s, e) => tb.SelectAll();
                    tb.MouseClick += (s, e) => tb.SelectAll();
                }
                // ComboBox (editable)
                else if (c is ComboBox cb)
                {
                    if (cb.DropDownStyle != ComboBoxStyle.DropDownList)
                    {
                        cb.Enter += (s, e) => cb.SelectAll();
                        cb.MouseClick += (s, e) => cb.SelectAll();
                    }
                }
                // NumericUpDown: interviene su TextBox interno
                else if (c is NumericUpDown nud)
                {
                    var inner = nud.Controls.OfType<TextBox>().FirstOrDefault();
                    if (inner != null)
                    {
                        inner.Enter += (s, e) => inner.SelectAll();
                        inner.MouseClick += (s, e) => inner.SelectAll();
                    }
                }

                // Recursión para contenedores (GroupBox, Panel, etc.)
                if (c.HasChildren)
                    AttachSelectAllBehavior(c);
            }
        }

        private void OnUnitAdded(object sender, EventArgs e)
        {
            CbUnitsDataBind();
        }

        private void OnUnitUpdated(object sender, EventArgs e)
        {
            CbUnitsDataBind();
        }

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL
                .GetAllUnits()
                .Select(p => new { p.Id, p.Abbreviation })
                .ToList();
            cbUnits.Update();
        }

        private void CleanUI()
        {
            txtIngredientName.Text = string.Empty;
            txtCost.Value = 0;
            txtAmountSoldBy.Value = 1;
            txtEfficiency.Value = 100;
            cbUnits.SelectedIndex = 0;
            txtProvider.Text = string.Empty;
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
            var newIngredient = new IngredientDTO
            {
                IngredientName = txtIngredientName.Text.Trim(),
                Cost = Convert.ToDouble(txtCost.Value),
                AmountSoldBy = Convert.ToDouble(txtAmountSoldBy.Value),
                Efficiency = Convert.ToDouble(txtEfficiency.Value / 100),
                UnitId = (long)cbUnits.SelectedValue,
                Provider = txtProvider.Text.Trim()
            };

            IngredientsBLL.CreateIngredient(newIngredient);
            GlobalUIEvents.Instance.DispatchOnIngredientAdded(this, EventArgs.Empty);
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            SaveIngredient();
            MessageBox.Show("Ingrediente creado exitosamente.", "Ingrediente.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void BtnAddAndContinue_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            SaveIngredient();
            MessageBox.Show("Ingrediente creado exitosamente.", "Ingrediente.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            CleanUI();
            txtIngredientName.Select();
        }
    }
}
