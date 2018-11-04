using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace Wendy.Module.Win.Controllers
{
    public partial class VCWinDetail : ViewController<DetailView>
    {
        public VCWinDetail()
        {
            InitializeComponent();
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.Items.Where(i => i.Id.StartsWith("b_")).ToList()
                .ForEach(i => { i.ControlCreated += I_ControlCreated; });
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            ((LayoutControl) View.Control).Items.Where(i => i.Name.StartsWith("b_")).ToList().ForEach(i =>
            {
                ((LayoutControlItem) i).SizeConstraintsType = SizeConstraintsType.SupportHorzAlignment;
            });
        }

        private void I_ControlCreated(object sender, EventArgs e)
        {
            if (((DXPropertyEditor) sender).Control is CheckEdit)
                ((CheckEdit) ((DXPropertyEditor) sender).Control).AutoSizeInLayoutControl = true;
        }
    }
}