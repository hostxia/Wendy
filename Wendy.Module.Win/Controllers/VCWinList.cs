using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;

namespace Wendy.Module.Win.Controllers
{
    public partial class VCWinList : ViewController
    {
        public VCWinList()
        {
            InitializeComponent();
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var control = View.Control as GridControl;
            var gridView = control?.MainView as GridView;
            if (gridView != null)
            {
                gridView.OptionsView.ColumnAutoWidth = false;
                gridView.Columns.ToList().ForEach(c => c.OptionsFilter.AutoFilterCondition =
                    AutoFilterCondition.Contains);
                gridView.OptionsView.ShowFooter = true;
                gridView.OptionsView.ShowAutoFilterRow = true;
            }

            if (View is ListView && !View.IsRoot && View.Id.Contains("_LookupListView"))
            {
                View.AllowNew.SetItemValue("Common", false);
            }

            if (View.Id == "TCC_EntityFile_LookupListView")
            {
                View.AllowNew.SetItemValue("Common", true);
            }

            if (View.Id == "StudentInfo_ListView" || View.Id == "ConsultRecord_ListView")
            {
                gridView.CustomDrawCell += GridView_CustomDrawCell;
            }

            Frame.GetController<OpenObjectController>().OpenObjectAction.Active.SetItemValue("Common", false);
        }

        private void GridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (!e.Column.Name.Contains("s_Phone"))
            {
                return;
            }
            e.DisplayText = !string.IsNullOrWhiteSpace(e.CellValue?.ToString()) && e.CellValue.ToString().Length >= 11
                ? e.CellValue.ToString().Substring(0, 3) + "****" + e.CellValue.ToString().Substring(7)
                : string.Empty;
        }
    }
}