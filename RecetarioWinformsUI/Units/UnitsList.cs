using RecetarioBackEnd.BLL.Interfaces;
using RecetarioWinformsUI.Events;
using RecetarioWinformsUI.Units;
using System.Data;

namespace RecetarioWinformsUI
{
    public partial class UnitsList : Form
    {
        private readonly IUnitsBLL UnitsBLL;

        public UnitsList(IUnitsBLL unitsBLL)
        {
            InitializeComponent();
            UnitsBLL = unitsBLL;

            LoadUnitsDataSource();

            GlobalUIEvents.Instance.OnUnitAdded += UnitAddWnd_UnitAdded;
            GlobalUIEvents.Instance.OnUnitUpdated += UnitUpdateWnd_OnUnitUpdated;
        }

        private void LoadUnitsDataSource()
        {
            var data = UnitsBLL.GetAllUnits()
                .Select(p => new { p.Id, p.Name, p.Abbreviation })
                .OrderBy(p => p.Name)
                .ToList();

            GridViewUnits.DataSource = data;
            GridViewUnits.Refresh();
        }

        private void UnitAddWnd_UnitAdded(object? sender, EventArgs e)
        {
            LoadUnitsDataSource();
        }

        private void UnitUpdateWnd_OnUnitUpdated(object sender, EventArgs e)
        {
            LoadUnitsDataSource();
        }

        private void BtnAddUnit_Click(object sender, EventArgs e)
        {
            var unitAddWnd = new UnitAdd(UnitsBLL);
            unitAddWnd.ShowDialog();
        }

        private void BtnUpdateUnit_Click(object sender, EventArgs e)
        {
            var selectedRow = GridViewUnits.SelectedRows[0];
            var unitId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            var unitUpdateWnd = new UnitUpdate(unitId, UnitsBLL);
            unitUpdateWnd.ShowDialog();
        }

        private void UnitsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            GlobalUIEvents.Instance.OnUnitAdded -= UnitAddWnd_UnitAdded;
            GlobalUIEvents.Instance.OnUnitUpdated -= UnitUpdateWnd_OnUnitUpdated;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
