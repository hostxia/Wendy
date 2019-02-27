using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace Wendy.Module.Controllers
{
    public partial class VCConsultRecordList : ViewController
    {
        private string _sT1 = "b_Distribution = False  And IsNull(s_InviteResult,'') != '确认无效' And IsNull(b_FilterResult,True) != False";
        private string _sT2 = "StudentInfo.LastContactRecord.dt_NextDate < AddDays(Today(),1) And IsNull(s_InviteResult,'') != '确认无效' And IsNull(b_FilterResult,True) != False";
        private string _sC1 = "";
        private string _sC2 = "";
        private string _sC3 = "";
        private string _sC4 = "";

        public VCConsultRecordList()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            scaFilter.SelectedIndex = 0;
            ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sT1);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        private void scaFilter_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            if (scaFilter.SelectedItem != null)
            {
                switch (scaFilter.SelectedItem.Data.ToString())
                {
                    case "T1":
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sT1);
                        break;
                    case "T2":
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sT2);
                        break;
                    case "C1":
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sC1);
                        break;
                    case "C2":
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sC2);
                        break;
                    case "C3":
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sC3);
                        break;
                    case "C4":
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", _sC4);
                        break;
                    default:
                        ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", null);
                        break;
                }
            }
            else
            {
                ((ListView)View).CollectionSource.SetCriteria("FullTextSearchCriteria", null);
            }
        }
    }
}
