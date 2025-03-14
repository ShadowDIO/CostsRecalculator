using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Units
{
    public partial class UnitUpdate : Form
    {
        private UnitDTO? UnitModel { get; set; }
        private readonly IUnitsBLL UnitsBLL;

        public UnitUpdate(int unitId, IUnitsBLL unitsBLL)
        {
            InitializeComponent();
            UnitsBLL = unitsBLL;

            LoadDataSource(unitId);

            LoadUIValues();

            txtName.Select();
        }

        private void LoadDataSource(int id)
        {
            UnitModel = UnitsBLL.GetUnit(id);
        }

        private void LoadUIValues()
        {
            txtName.Text = UnitModel?.Name;
            txtAbbreviation.Text = UnitModel?.Abbreviation;
        }

        private bool ValidateUnitUIFields()
        {
            var validationResultsFailed = !string.IsNullOrEmpty(txtAbbreviation.Text + txtName.Text);
            return validationResultsFailed;
        }

        private void btnUpdateUnit_Click(object sender, EventArgs e)
        {
            if (!ValidateUnitUIFields())
            {
                MessageBox.Show("Nombre y abreviación son campos requeridos.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            UnitModel.Name = txtName.Text;
            UnitModel.Abbreviation = txtAbbreviation.Text;

            UnitsBLL.UpdateUnit(UnitModel);

            GlobalUIEvents.Instance.DispatchOnUnitUpdated(sender, e);

            Close();
        }
    }
}
