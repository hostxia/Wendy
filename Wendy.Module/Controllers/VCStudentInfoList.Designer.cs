namespace Wendy.Module.Controllers
{
    partial class VCStudentInfoList
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem1 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem2 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.scaFilter = new DevExpress.ExpressApp.Actions.SingleChoiceAction();
            this.saBack = new DevExpress.ExpressApp.Actions.SimpleAction();
            // 
            // scaFilter
            // 
            this.scaFilter.Caption = "筛选";
            this.scaFilter.Category = "FullTextSearch";
            this.scaFilter.ConfirmationMessage = null;
            this.scaFilter.Id = "StudentInfo.scaFilter";
            choiceActionItem1.Caption = "今天的咨询";
            choiceActionItem1.Data = "T";
            choiceActionItem1.Id = "Entry 1";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "所有咨询";
            choiceActionItem2.Data = "A";
            choiceActionItem2.Id = "Entry 2";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            this.scaFilter.Items.Add(choiceActionItem1);
            this.scaFilter.Items.Add(choiceActionItem2);
            this.scaFilter.ToolTip = null;
            // 
            // saBack
            // 
            this.saBack.Caption = "退回";
            this.saBack.Category = "RecordEdit";
            this.saBack.ConfirmationMessage = "是否确认退回学生资料？";
            this.saBack.Id = "saBack";
            this.saBack.ToolTip = null;
            this.saBack.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.saBack_Execute);
            // 
            // VCStudentInfoList
            // 
            this.Actions.Add(this.scaFilter);
            this.Actions.Add(this.saBack);
            this.TargetObjectType = typeof(Wendy.Module.BusinessObjects.StudentInfo);
            this.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaFilter;
        private DevExpress.ExpressApp.Actions.SimpleAction saBack;
    }
}
