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

            IngredientsBLL = ingredientsBLL;
            this.UnitsBLL = unitsBLL;

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
            cbUnits.DataSource = UnitsBLL.GetAllUnits().Select(p => new { p.Id, p.Abbreviation }).ToList();
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
            Ingredient.IngredientName = txtIngredientName.Text.Trim();
            Ingredient.Cost = Convert.ToDouble(txtCost.Value);
            Ingredient.AmountSoldBy = Convert.ToDouble(txtAmountSoldBy.Value);
            Ingredient.Efficiency = Convert.ToDouble(txtEfficiency.Value / 100);
            Ingredient.UnitId = (long)cbUnits.SelectedValue;
            Ingredient.Provider = txtProvider.Text.Trim();

            IngredientsBLL.UpdateIngredient(Ingredient);

            GlobalUIEvents.Instance.DispatchOnIngredientAdded(this, new EventArgs());
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            SaveIngredient();

            MessageBox.Show("Ingrediente actualizado exitosamente.", "Ingrediente.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
    }
}
