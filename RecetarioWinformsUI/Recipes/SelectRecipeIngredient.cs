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

        private List<int> IngredientsAlreadyUsed;
        private List<IngredientDTO> Ingredients;
        private readonly IIngredientsBLL IngredientsBLL;

        public SelectRecipeIngredient(IEnumerable<int> ingredientsAlreadyUsed, IIngredientsBLL ingredientsBLL)
        {
            IngredientsAlreadyUsed = ingredientsAlreadyUsed.ToList();
            IngredientsBLL = ingredientsBLL;

            InitializeComponent();

            FetchIngredientsDataSource();
            CbIngredientNameDataBind();
        }

        private void FetchIngredientsDataSource()
        {
            var availableIngredients = IngredientsBLL.GetAllIngredients()
                .Where(p => !IngredientsAlreadyUsed.Contains((int)p.Id));

            Ingredients = availableIngredients.ToList();
        }

        private void CbIngredientNameDataBind()
        {
            var availableIngredients = Ingredients
                .Select(p => new { p.Id, p.IngredientName });

            cbIngredientName.DataSource = availableIngredients.ToList();
            cbIngredientName.Update();

            cbIngredientName.AutoCompleteCustomSource.AddRange(availableIngredients.Select(p => p.IngredientName).ToArray());
            cbIngredientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CbIngredientName_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedIngredient = Ingredients.First(p => (int)p.Id == Convert.ToInt32(cbIngredientName.SelectedValue));

            txtUnits.Text = selectedIngredient.UnitName;
            txtProvider.Text = selectedIngredient.Provider;

            RecalculateValues();
        }

        private void TxtAmount_ValueChanged(object sender, EventArgs e)
        {
            RecalculateValues();
        }

        private void TxtEfficiency_ValueChanged(object sender, EventArgs e)
        {
            RecalculateValues();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (!ValidateUI())
                return;

            if (cbIngredientName.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un ingrediente antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedIngredientDTO = Ingredients.First(p => p.Id == (long)cbIngredientName.SelectedValue);

            var recipeIngredient = new RecipeIngredient()
            {
                IngredientId = selectedIngredientDTO.Id,
                Ingredient = new Ingredient
                {
                    Id = selectedIngredientDTO.Id,
                    IngredientName = selectedIngredientDTO.IngredientName,
                    Cost = selectedIngredientDTO.Cost,
                    AmountSoldBy = selectedIngredientDTO.AmountSoldBy,
                    Efficiency = selectedIngredientDTO.Efficiency,
                    UnitId = selectedIngredientDTO.UnitId,
                    Provider = selectedIngredientDTO.Provider
                },
                Quantity = Convert.ToDouble(txtAmount.Value),
                Efficiency = Convert.ToDouble(txtEfficiency.Value / 100)
            };

            OnIngredientSelected?.Invoke(this, new IngredientSelectedEventArgs(recipeIngredient));
            Close();
        }



        private bool ValidateUI()
        {
            if (cbIngredientName.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un ingrediente antes de continuar.", "Campo requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void RecalculateValues()
        {
            var selectedIngredient = Ingredients.First(p => (int)p.Id == Convert.ToInt32(cbIngredientName.SelectedValue));

            txtCalculatedEfficiency.Text = (txtAmount.Value * (txtEfficiency.Value / 100)).ToString();
            txtCost.Text = $"{((selectedIngredient.Cost / selectedIngredient.AmountSoldBy) * (double)txtAmount.Value):C2}";
        }
    }
}
