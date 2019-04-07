using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using System.Linq;
using System.Windows.Forms;
using Wendy.Module.BusinessObjects;
using Wendy.Module.Win.Form;

namespace Wendy.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class VCConsultList : ViewController
    {

        public VCConsultList()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            saDistribution.Active.SetItemValue("Security",
                ((SysUser) SecuritySystem.CurrentUser).IsUserInRole("校长") ||
                ((SysUser) SecuritySystem.CurrentUser).IsUserInRole("前台"));
            Frame.GetController<NewObjectViewController>().ObjectCreating += VCConsultList_ObjectCreating;
            // Perform various tasks depending on the target View.
        }


        private void VCConsultList_ObjectCreating(object sender, ObjectCreatingEventArgs e)
        {
            var frm = new XFrmPhone(e.ObjectSpace);
            if (frm.ShowDialog() == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            var consult = e.ObjectSpace.CreateObject<ConsultRecord>();
            if (frm.StudentInfo != null)
            {
                consult.StudentInfo = frm.StudentInfo;
            }
            else
            {
                consult.StudentInfo = e.ObjectSpace.CreateObject<StudentInfo>();
                consult.StudentInfo.s_Phone = frm.PhoneCode;
            }

            e.NewObject = consult;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void saDistribution_Execute(object sender, DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs e)
        {
            var listConsult = View.SelectedObjects.Cast<ConsultRecord>().ToList();
            if (!listConsult.Any()) return;
            var frm = new XFrmDistribution(ObjectSpace);
            if (frm.ShowDialog() != DialogResult.OK) return;

            listConsult.ForEach(r =>
            {
                r.FilterUser = frm.FilterUser;
                r.InviteUser = frm.InviteUser;
                r.Save();
            });
            ObjectSpace.CommitChanges();
            View.RefreshDataSource();
        }
    }
}
