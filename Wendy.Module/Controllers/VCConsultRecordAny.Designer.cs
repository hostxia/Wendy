namespace Wendy.Module.Controllers
{
    partial class VCConsultRecordAny
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saShowStudentInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saShowStudentInfo
            // 
            this.saShowStudentInfo.Caption = "打开学生资料";
            this.saShowStudentInfo.Category = "RecordEdit";
            this.saShowStudentInfo.ConfirmationMessage = null;
            this.saShowStudentInfo.Id = "saShowStudentInfo";
            this.saShowStudentInfo.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.saShowStudentInfo.ToolTip = null;
            this.saShowStudentInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saShowStudentInfo_Execute);
            // 
            // VCConsultRecordAny
            // 
            this.Actions.Add(this.saShowStudentInfo);
            this.TargetObjectType = typeof(Wendy.Module.BusinessObjects.ConsultRecord);
            this.TypeOfView = typeof(DevExpress.ExpressApp.View);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction saShowStudentInfo;
    }
}
