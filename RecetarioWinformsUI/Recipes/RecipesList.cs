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

        public RecipesList(
            IRecipesBLL recipesBLL,
            IRecipeIngredientsBLL recipeIngredientsBLL,
            IRecipeSubRecipesBLL recipeSubRecipesBLL,
            IUnitsBLL unitsBLL,
            IIngredientsBLL ingredientsBLL)
        {
            InitializeComponent();

            // Habilita SelectAll en los textboxes al hacer clic o tab
            AttachSelectAllBehavior(this);

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
            Recipes = RecipesBLL
                .GetAllRecipes(includeIngredientsAndSubRecipes: true)
                .ToList();
        }

        private void GvRecipesDataBind(IEnumerable<RecipeDTO> recipes)
        {
            var data = recipes.Select(p => new
            {
                Id = p.Id,
                RecipeName = StringHelper.TrimLongName(p.RecipeName),
                RecipeEfficiency = $"{p.Efficiency:P}",
                RecipeCost = $"{RecipesBLL.CalculateRecipeCosts(p):C2}"
            })
            .ToList();

            gvRecipes.DataSource = data;
            gvRecipes.Refresh();
            btnUpdateRecipe.Enabled = btnViewRecipe.Enabled = data.Count > 0;
        }

        private void FilterRecipesGridView()
        {
            var term = txtSearchRecipeName.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(term))
            {
                GvRecipesDataBind(Recipes);
                return;
            }

            var filtered = Recipes
                .Where(p => p.RecipeName.ToLower().Contains(term));

            GvRecipesDataBind(filtered);
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
            using var frmAdd = new AddRecipe(
                RecipesBLL,
                RecipeIngredientsBLL,
                RecipeSubRecipesBLL,
                UnitsBLL,
                IngredientsBLL);
            frmAdd.ShowDialog();
        }

        private void BtnUpdateRecipe_Click(object sender, EventArgs e)
        {
            var id = gvRecipes.SelectedRows[0].Cells["Id"].Value as long?;
            if (id == null)
            {
                MessageBox.Show("Tried to Update recipe without Id", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using var frmUpdate = new UpdateRecipe(
                (int)id.Value,
                RecipesBLL,
                UnitsBLL,
                IngredientsBLL,
                RecipeIngredientsBLL,
                RecipeSubRecipesBLL);
            frmUpdate.ShowDialog();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GvRecipes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == gvRecipes.Columns["RecipeName"].Index)
            {
                var id = gvRecipes.Rows[e.RowIndex].Cells["Id"].Value as long?;
                if (id == null) return;

                var cell = gvRecipes.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = Recipes.FirstOrDefault(p => p.Id == id)?.RecipeName;
            }
        }

        private void GvRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OpenAndShowViewRecipeForm();
        }

        private void OpenAndShowViewRecipeForm()
        {
            var id = gvRecipes.SelectedRows[0].Cells["Id"].Value as long?;
            if (id == null)
            {
                MessageBox.Show("Tried to View recipe without Id", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frmView = new ViewRecipe((int)id.Value, RecipesBLL)
            {
                MdiParent = this.MdiParent
            };
            frmView.Show();
        }

        /// <summary>
        /// Recorre recursivamente todos los controles hijos y suscribe Enter y MouseClick
        /// para hacer SelectAll() en TextBoxBase y NumericUpDown.
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
