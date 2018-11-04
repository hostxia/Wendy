using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;

namespace Wendy.Module.Controllers
{
    public partial class VCConsultRecordList : ViewController
    {
        private string _sCustomCondition = "StudentInfo.LastContactRecord.dt_NextDate < AddDays(Today(),1)";

        public VCConsultRecordList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ((ListView)View).CollectionSource.SetCriteria("Custom", _sCustomCondition);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            scaFilter.SelectedIndex = 0;
            Frame.GetController<FilterController>().FullTextFilterAction.Execute += FullTextFilterAction_Execute; ;
        }

        private void FullTextFilterAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            if (scaFilter.SelectedItem != null)
            {
                switch (scaFilter.SelectedItem.Data.ToString())
                {
                    case "T":
                        ((ListView)View).CollectionSource.SetCriteria("Custom", _sCustomCondition);
                        break;
                    default:
                        ((ListView)View).CollectionSource.SetCriteria("Custom", null);
                        break;
                }
            }
            else
            {
                ((ListView)View).CollectionSource.SetCriteria("Custom", null);
            }
        }
    }
}
