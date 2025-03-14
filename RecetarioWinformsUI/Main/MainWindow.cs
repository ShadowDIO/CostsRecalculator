using RecetarioBackEnd.BLL.Interfaces;
using RecetarioWinformsUI.Ingredients;
using RecetarioWinformsUI.Recipes;

namespace RecetarioWinformsUI.Main
{
    public partial class MainWindow : Form
    {
        private readonly IIngredientsBLL _ingredientsBLL;
        private readonly IUnitsBLL _unitsBLL;
        private readonly IRecipesBLL _recipesBLL;
        private readonly IRecipeIngredientsBLL _recipeIngredientsBLL;
        private readonly IRecipeSubRecipesBLL _recipeSubRecipesBLL;

        public MainWindow(IIngredientsBLL ingredientsBLL, IUnitsBLL unitsBLL, IRecipesBLL recipesBLL, IRecipeIngredientsBLL recipeIngredientsBLL, IRecipeSubRecipesBLL recipeSubRecipesBLL)
        {
            InitializeComponent();

            _ingredientsBLL = ingredientsBLL;
            _unitsBLL = unitsBLL;
            _recipesBLL = recipesBLL;
            _recipeIngredientsBLL = recipeIngredientsBLL;
            _recipeSubRecipesBLL = recipeSubRecipesBLL;
        }


        private void listaIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childWindow = new IngredientsList(_ingredientsBLL, _unitsBLL);

            childWindow.MdiParent = this;

            childWindow.Show();
        }

        private void agregarIngredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childWindow = new AddIngredient(_ingredientsBLL, _unitsBLL);

            childWindow.MdiParent = this;

            childWindow.Show();
        }

        private void buscarRecetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childWindow = new RecipesList(_recipesBLL, _recipeIngredientsBLL, _recipeSubRecipesBLL, _unitsBLL, _ingredientsBLL);

            childWindow.MdiParent = this;

            childWindow.Show();
        }

        private void crearRecetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childWindow = new AddRecipe(_recipesBLL, _recipeIngredientsBLL, _recipeSubRecipesBLL, _unitsBLL, _ingredientsBLL);

            childWindow.MdiParent = this;

            childWindow.Show();
        }

        private void listaUnidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var childWindow = new UnitsList(_unitsBLL);

            childWindow.MdiParent = this;

            childWindow.Show();
        }
    }
}
