using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioWinformsUI.Events;

namespace RecetarioWinformsUI.Ingredients
{
    public partial class IngredientsList : Form
    {
        private List<IngredientDTO> Ingredients = new List<IngredientDTO>();
        private readonly IIngredientsBLL IngredientsBLL;
        private readonly IUnitsBLL UnitsBLL;

        public IngredientsList(IIngredientsBLL ingredientsBLL, IUnitsBLL unitsBLL)
        {
            InitializeComponent();

            // Habilita SelectAll en todos los controles de entrada
            AttachSelectAllBehavior(this);

            IngredientsBLL = ingredientsBLL;
            UnitsBLL = unitsBLL;

            LoadIngredientsDataSource();
            GvIngredientsDataBind(Ingredients);

            GlobalUIEvents.Instance.OnIngredientAdded += OnIngredientAdded;
            GlobalUIEvents.Instance.OnIngredientUpdated += OnIngredientUpdated;
            GlobalUIEvents.Instance.OnUnitUpdated += OnUnitUpdated;
        }

        private void LoadIngredientsDataSource()
        {
            Ingredients = IngredientsBLL.GetAllIngredients().ToList();
        }

        private void GvIngredientsDataBind(IEnumerable<IngredientDTO> ingredients)
        {
            var data = ingredients
                .Select(p => new
                {
                    Id = p.Id,
                    IngredientName = p.IngredientName,
                    Cost = $"{p.Cost:C2}",
                    AmountSoldBy = p.AmountSoldBy,
                    UnitName = p.UnitName,
                    Efficiency = $"{p.Efficiency:P}",
                    Provider = p.Provider
                })
                .ToList();

            gvIngredients.DataSource = data;
            gvIngredients.Refresh();
            btnUpdateIngredient.Enabled = data.Count > 0;
        }

        private void FilterIngredientsGridView()
        {
            if (string.IsNullOrWhiteSpace(txtSearchIngredient.Text))
            {
                GvIngredientsDataBind(Ingredients);
                return;
            }

            var query = txtSearchIngredient.Text.Trim().ToLower();
            IEnumerable<IngredientDTO> filteredSource;

            if (rdName.Checked)
                filteredSource = Ingredients.Where(x => x.IngredientName.ToLower().Contains(query));
            else
                filteredSource = Ingredients.Where(x =>
                    !string.IsNullOrEmpty(x.Provider) && x.Provider.ToLower().Contains(query));

            GvIngredientsDataBind(filteredSource);
        }

        private void OnIngredientAdded(object sender, EventArgs e)
        {
            LoadIngredientsDataSource();
            GvIngredientsDataBind(Ingredients);
            FilterIngredientsGridView();
        }

        private void OnIngredientUpdated(object sender, EventArgs e)
        {
            LoadIngredientsDataSource();
            GvIngredientsDataBind(Ingredients);
            FilterIngredientsGridView();
        }

        private void OnUnitUpdated(object sender, EventArgs e)
        {
            LoadIngredientsDataSource();
            GvIngredientsDataBind(Ingredients);
        }

        private void TxtSearchIngredient_TextChanged(object sender, EventArgs e)
        {
            FilterIngredientsGridView();
        }

        private void RdName_CheckedChanged(object sender, EventArgs e)
        {
            FilterIngredientsGridView();
        }

        private void RdProvider_CheckedChanged(object sender, EventArgs e)
        {
            FilterIngredientsGridView();
        }

        private void BtnAddIngredient_Click(object sender, EventArgs e)
        {
            var frmAddIngredient = new AddIngredient(IngredientsBLL, UnitsBLL);
            frmAddIngredient.ShowDialog();
        }

        private void BtnUpdateIngredient_Click(object sender, EventArgs e)
        {
            var selectedIngredientId = gvIngredients.SelectedRows[0].Cells["Id"].Value as long?;
            if (!selectedIngredientId.HasValue)
            {
                MessageBox.Show("Tried to update ingredient without Id", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var frmUpdateIngredient = new UpdateIngredient((int)selectedIngredientId.Value, IngredientsBLL, UnitsBLL);
            frmUpdateIngredient.ShowDialog();
        }

        private void GvIngredients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BtnUpdateIngredient_Click(sender, e);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IngredientsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalUIEvents.Instance.OnIngredientAdded -= OnIngredientAdded;
            GlobalUIEvents.Instance.OnIngredientUpdated -= OnIngredientUpdated;
            GlobalUIEvents.Instance.OnUnitUpdated -= OnUnitUpdated;
        }

        /// <summary>
        /// Recorre recursivamente controles y suscribe Enter y MouseClick para SelectAll().
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
