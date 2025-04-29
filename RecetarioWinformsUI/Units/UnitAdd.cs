using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Units
{
    public partial class UnitAdd : Form
    {
        private readonly IUnitsBLL UnitsBLL;

        public UnitAdd(IUnitsBLL unitsBLL)
        {
            InitializeComponent();
            UnitsBLL = unitsBLL;

            // Habilita SelectAll en txtName y txtAbbreviation
            AttachSelectAllBehavior(this);

            txtName.Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateUnitUIFields())
            {
                MessageBox.Show(
                    "Nombre y abreviación son campos requeridos.",
                    "Campos requeridos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            AddUnit();
            GlobalUIEvents.Instance.DispatchOnUnitAdded(sender, e);
            Close();
        }

        private void btnAddAndContinue_Click(object sender, EventArgs e)
        {
            if (!ValidateUnitUIFields())
            {
                MessageBox.Show(
                    "Nombre y abreviación son campos requeridos.",
                    "Campos requeridos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            AddUnit();
            GlobalUIEvents.Instance.DispatchOnUnitAdded(sender, e);
            MessageBox.Show(
                "Unidad agregada exitosamente.",
                "Éxito!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            CleanFields();
            txtName.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddUnit()
        {
            var unitDTO = new UnitDTO
            {
                Name = txtName.Text.Trim(),
                Abbreviation = txtAbbreviation.Text.Trim()
            };
            UnitsBLL.CreateUnit(unitDTO);
        }

        private void CleanFields()
        {
            txtName.Text = string.Empty;
            txtAbbreviation.Text = string.Empty;
        }

        private bool ValidateUnitUIFields()
        {
            // Ambos campos deben tener al menos un carácter
            return
                !string.IsNullOrWhiteSpace(txtName.Text) &&
                !string.IsNullOrWhiteSpace(txtAbbreviation.Text);
        }

        /// <summary>
        /// Recorre recursivamente todos los controles hijos y suscribe
        /// Enter y MouseClick para hacer SelectAll() en TextBoxBase.
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
                // Si hubiera NumericUpDown en esta forma:
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
