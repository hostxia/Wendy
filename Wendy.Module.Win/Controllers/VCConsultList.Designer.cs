namespace Wendy.Module.Win.Controllers
{
    partial class VCConsultList
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
            this.saDistribution = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // saDistribution
            // 
            this.saDistribution.Caption = "分配";
            this.saDistribution.Category = "RecordEdit";
            this.saDistribution.ConfirmationMessage = null;
            this.saDistribution.Id = "saDistribution";
            this.saDistribution.ToolTip = null;
            this.saDistribution.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saDistribution_Execute);
            // 
            // VCConsultList
            // 
            this.Actions.Add(this.saDistribution);
            this.TargetObjectType = typeof(Wendy.Module.BusinessObjects.ConsultRecord);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction saDistribution;
    }
}
