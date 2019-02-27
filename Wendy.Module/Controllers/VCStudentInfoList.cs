using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Xpo;
using System.Linq;
using Wendy.Module.BusinessObjects;

namespace Wendy.Module.Controllers
{
    public partial class VCStudentInfoList : ViewController
    {
        private string _sCustomCondition =
            "LastContactRecord.dt_RecordDate >= Today() And LastContactRecord.dt_RecordDate < AddDays(Today(),1) Or ConsultRecords.Min(dt_ConsultDate) >= Today() And ConsultRecords.Min(dt_ConsultDate) < AddDays(Today(),1)";

        private readonly string _sTMKCondition = $"(LastContactRecord.dt_NextDate < AddDays(Today(),1) Or ConsultRecords.Min(dt_ConsultDate) >= Today() And ConsultRecords.Min(dt_ConsultDate) < AddDays(Today(),1)) And (s_Valid = '待定' Or s_Valid = '') And OwnerTMK.Oid = '{SecuritySystem.CurrentUserId}' And OwnerCC is Null";
        public VCStudentInfoList()
        {
            InitializeComponent();
            saBack.Active.SetItemValue("Custom", false);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ((ListView)View).CollectionSource.SetCriteria("Custom",((SysUser)SecuritySystem.CurrentUser).IsUserInRole("TMK") ? _sTMKCondition : _sCustomCondition);
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
                        ((ListView)View).CollectionSource.SetCriteria("Custom", ((SysUser)SecuritySystem.CurrentUser).IsUserInRole("TMK") ? _sTMKCondition : _sCustomCondition);
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

        private void saBack_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var uow = new UnitOfWork(((XPObjectSpace)ObjectSpace).Session.DataLayer);
            e.SelectedObjects.Cast<StudentInfo>().ToList().ForEach(s =>
            {
                var stu = uow.GetObjectByKey<StudentInfo>(s.Oid);
                if (stu == null)
                {
                    return;
                }

                //stu.b_IsBack = true;
                stu.Save();
                uow.CommitChanges();
            });
        }
    }
}
