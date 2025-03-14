using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Events;
using RecetarioWinformsUI.Helpers;

namespace RecetarioWinformsUI.Recipes
{
    public partial class RecipesList : Form
    {
        private List<RecipeDTO> Recipes = new();
        private readonly IRecipesBLL RecipesBLL;
        private readonly IRecipeIngredientsBLL RecipeIngredientsBLL;
        private readonly IRecipeSubRecipesBLL RecipeSubRecipesBLL;
        private readonly IUnitsBLL UnitsBLL;
        private readonly IIngredientsBLL IngredientsBLL;

        public RecipesList(IRecipesBLL recipesBLL, IRecipeIngredientsBLL recipeIngredientsBLL, IRecipeSubRecipesBLL recipeSubRecipesBLL, IUnitsBLL unitsBLL, IIngredientsBLL ingredientsBLL)
        {
            InitializeComponent();
            RecipesBLL = recipesBLL;
            RecipeIngredientsBLL = recipeIngredientsBLL;
            RecipeSubRecipesBLL = recipeSubRecipesBLL;
            UnitsBLL = unitsBLL;
            IngredientsBLL = ingredientsBLL;

            LoadRecipeDataSource();
            GvRecipesDataBind(Recipes);

            GlobalUIEvents.Instance.OnRecipeAdded += OnRecipeAdded;
            GlobalUIEvents.Instance.OnRecipeUpdated += OnRecipeUpdated;
        }

        private void LoadRecipeDataSource()
        {
            Recipes = RecipesBLL.GetAllRecipes(includeIngredientsAndSubRecipes: true).ToList();
        }

        private void GvRecipesDataBind(IEnumerable<RecipeDTO> recipes)
        {
            var data = recipes.Select(p =>
            new
            {
                Id = p.Id,
                RecipeName = StringHelper.TrimLongName(p.RecipeName),
                RecipeEfficiency = $"{p.Efficiency:P}",
                RecipeCost = $"{RecipesBLL.CalculateRecipeCosts(p):C2}",
            }).ToList();

            gvRecipes.DataSource = data;

            gvRecipes.Refresh();

            btnUpdateRecipe.Enabled = btnViewRecipe.Enabled = data.Count > 0;
        }

        private void FilterRecipesGridView()
        {
            if (string.IsNullOrEmpty(txtSearchRecipeName.Text.Trim()))
            {
                GvRecipesDataBind(Recipes);
                return;
            }

            var filteredSource = Recipes.Where(p => p.RecipeName.ToLower().Contains(txtSearchRecipeName.Text.ToLower()));
            GvRecipesDataBind(filteredSource);
        }

        private void OnRecipeAdded(object sender, EventArgs e)
        {
            LoadRecipeDataSource();
            GvRecipesDataBind(Recipes);
        }

        private void OnRecipeUpdated(object sender, EventArgs e)
        {
            LoadRecipeDataSource();
            GvRecipesDataBind(Recipes);
        }

        private void TxtSearchRecipeName_TextChanged(object sender, EventArgs e)
        {
            FilterRecipesGridView();
        }

        private void RecipesList_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalUIEvents.Instance.OnRecipeAdded -= OnRecipeAdded;
            GlobalUIEvents.Instance.OnRecipeUpdated -= OnRecipeUpdated;
        }

        private void BtnViewRecipe_Click(object sender, EventArgs e)
        {
            OpenAndShowViewRecipeForm();
        }

        private void BtnAddRecipe_Click(object sender, EventArgs e)
        {
            var frmAddRecipe = new AddRecipe(RecipesBLL, RecipeIngredientsBLL, RecipeSubRecipesBLL, UnitsBLL, IngredientsBLL);
            frmAddRecipe.ShowDialog();
        }

        private void BtnUpdateRecipe_Click(object sender, EventArgs e)
        {
            var recipeIdSelected = gvRecipes.SelectedRows[0].Cells["Id"].Value as long?;

            if (recipeIdSelected == null)
            {
                MessageBox.Show("Tried to Update recipe without Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frmUpdateRecipe = new UpdateRecipe((int)recipeIdSelected.Value, RecipesBLL, UnitsBLL, IngredientsBLL);
            frmUpdateRecipe.ShowDialog();
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GvRecipes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gvRecipes.Columns["RecipeName"].Index)
            {
                var recipeId = gvRecipes.Rows[e.RowIndex].Cells["Id"].Value as long?;

                if (recipeId == null)
                {
                    MessageBox.Show("Tried to access recipe without Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var cell = gvRecipes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = Recipes.FirstOrDefault(p => p.Id == recipeId)?.RecipeName;
            }
        }

        private void GvRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenAndShowViewRecipeForm();
        }

        private void OpenAndShowViewRecipeForm()
        {
            var recipeIdSelected = gvRecipes.SelectedRows[0].Cells["Id"].Value as long?;

            if (recipeIdSelected == null)
            {
                MessageBox.Show("Tried to View recipe without Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frmViewRecipe = new ViewRecipe((int)recipeIdSelected.Value, RecipesBLL) // Pasamos el BLL al formulario
            {
                MdiParent = this.MdiParent
            };

            frmViewRecipe.Show();
        }
    }
}
