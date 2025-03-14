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

            IngredientsBLL = ingredientsBLL;
            UnitsBLL = unitsBLL;

            CbUnitsDataBind();

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

        private void CbUnitsDataBind()
        {
            cbUnits.DataSource = UnitsBLL.GetAllUnits().Select(p => new { p.Id, p.Abbreviation }).ToList();
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
            if (string.IsNullOrEmpty(txtIngredientName.Text.Trim()))
            {
                MessageBox.Show("El campo Nombre no puede estar vacío.", "Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtProvider.Text.Trim()))
            {
                MessageBox.Show("El campo Proveedor no puede estar vacío.", "Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void SaveIngredient()
        {
            var newIngredient = new IngredientDTO()
            {
                IngredientName = txtIngredientName.Text.Trim(),
                Cost = Convert.ToDouble(txtCost.Value),
                AmountSoldBy = Convert.ToDouble(txtAmountSoldBy.Value),
                Efficiency = Convert.ToDouble(txtEfficiency.Value / 100),
                UnitId = (long)cbUnits.SelectedValue,
                Provider = txtProvider.Text.Trim()
            };

            IngredientsBLL.CreateIngredient(newIngredient);

            GlobalUIEvents.Instance.DispatchOnIngredientAdded(this, new EventArgs());
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            SaveIngredient();

            MessageBox.Show("Ingrediente creado exitosamente.", "Ingrediente.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void BtnAddAndContinue_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            SaveIngredient();

            MessageBox.Show("Ingrediente creado exitosamente.", "Ingrediente.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CleanUI();

            txtIngredientName.Select();
        }
    }
}
