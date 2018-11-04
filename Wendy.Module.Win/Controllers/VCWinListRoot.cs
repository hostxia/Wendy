using System;
using DevExpress.ExpressApp;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Wendy.Module.Win.Controllers
{
    public class VCWinListRoot : ViewController<ListView>
    {
        private GridView _gridView;

        public VCWinListRoot()
        {
            TargetViewNesting = Nesting.Root;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var control = View.Control as GridControl;
            _gridView = control?.MainView as GridView;
            if (_gridView != null)
            {
                _gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
                _gridView.RowCountChanged += _gridView_RowCountChanged;
            }
        }

        private void _gridView_RowCountChanged(object sender, EventArgs e)
        {
            _gridView.IndicatorWidth = _gridView.RowCount.ToString().Length * 10 + 10;
        }

        private void GridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0) return;
            e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }
    }
}