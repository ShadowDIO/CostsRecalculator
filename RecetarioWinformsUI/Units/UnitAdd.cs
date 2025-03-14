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
            txtName.Select();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateUnitUIFields())
            {
                MessageBox.Show("Nombre y abreviación son campos requeridos.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                MessageBox.Show("Nombre y abreviación son campos requeridos.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AddUnit();

            GlobalUIEvents.Instance.DispatchOnUnitAdded(sender, e);

            MessageBox.Show("Unidad agregada exitosamente.", "Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Name = txtName.Text,
                Abbreviation = txtAbbreviation.Text
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
            var validationResultsFailed = !string.IsNullOrEmpty(txtAbbreviation.Text.Trim() + txtName.Text.Trim());
            return validationResultsFailed;
        }
    }
}
