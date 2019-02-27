using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using Wendy.Module.BusinessObjects;

namespace Wendy.Module.Controllers
{
    public partial class VCConsultRecordAny : ViewController
    {
        public VCConsultRecordAny()
        {
            InitializeComponent();
            saShowStudentInfo.Active.SetItemValue("Custom", false);
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }

        private void saShowStudentInfo_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var consultRecord = View.CurrentObject as ConsultRecord;
            if (consultRecord?.StudentInfo == null)
            {
                return;
            }

            ListViewProcessCurrentObjectController.ShowObject(consultRecord.StudentInfo, e.ShowViewParameters, Application, new Frame(Application, TemplateContext.ApplicationWindow), View);
        }
    }
}
