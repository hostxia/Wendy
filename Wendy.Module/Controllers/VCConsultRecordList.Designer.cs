namespace Wendy.Module.Controllers
{
    partial class VCConsultRecordList
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
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem4 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem5 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem6 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem7 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.scaFilter = new DevExpress.ExpressApp.Actions.SingleChoiceAction();
            // 
            // scaFilter
            // 
            this.scaFilter.Caption = "筛选";
            this.scaFilter.Category = "FullTextSearch";
            this.scaFilter.ConfirmationMessage = null;
            this.scaFilter.DefaultItemMode = DevExpress.ExpressApp.Actions.DefaultItemMode.LastExecutedItem;
            this.scaFilter.EmptyItemsBehavior = DevExpress.ExpressApp.Actions.EmptyItemsBehavior.None;
            this.scaFilter.Id = "ConsultRecord.scaFilter";
            this.scaFilter.ImageName = "Action_Filter";
            choiceActionItem1.Caption = "今日任务(前台)";
            choiceActionItem1.Data = "T1";
            choiceActionItem1.Id = "Entry 7";
            choiceActionItem1.ImageName = null;
            choiceActionItem1.Shortcut = null;
            choiceActionItem1.ToolTip = null;
            choiceActionItem2.Caption = "今日任务(顾问)";
            choiceActionItem2.Data = "T2";
            choiceActionItem2.Id = "Entry 3";
            choiceActionItem2.ImageName = null;
            choiceActionItem2.Shortcut = null;
            choiceActionItem2.ToolTip = null;
            choiceActionItem3.Caption = "今日咨询";
            choiceActionItem3.Data = "C1";
            choiceActionItem3.Id = "Entry 1";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            choiceActionItem4.Caption = "本周咨询";
            choiceActionItem4.Data = "C2";
            choiceActionItem4.Id = "Entry 4";
            choiceActionItem4.ImageName = null;
            choiceActionItem4.Shortcut = null;
            choiceActionItem4.ToolTip = null;
            choiceActionItem5.Caption = "本月咨询";
            choiceActionItem5.Data = "C3";
            choiceActionItem5.Id = "Entry 5";
            choiceActionItem5.ImageName = null;
            choiceActionItem5.Shortcut = null;
            choiceActionItem5.ToolTip = null;
            choiceActionItem6.Caption = "本年咨询";
            choiceActionItem6.Data = "C4";
            choiceActionItem6.Id = "Entry 6";
            choiceActionItem6.ImageName = null;
            choiceActionItem6.Shortcut = null;
            choiceActionItem6.ToolTip = null;
            choiceActionItem7.Caption = "所有咨询";
            choiceActionItem7.Data = "A";
            choiceActionItem7.Id = "Entry 2";
            choiceActionItem7.ImageName = null;
            choiceActionItem7.Shortcut = null;
            choiceActionItem7.ToolTip = null;
            this.scaFilter.Items.Add(choiceActionItem1);
            this.scaFilter.Items.Add(choiceActionItem2);
            this.scaFilter.Items.Add(choiceActionItem3);
            this.scaFilter.Items.Add(choiceActionItem4);
            this.scaFilter.Items.Add(choiceActionItem5);
            this.scaFilter.Items.Add(choiceActionItem6);
            this.scaFilter.Items.Add(choiceActionItem7);
            this.scaFilter.ShowItemsOnClick = true;
            this.scaFilter.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.scaFilter.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.scaFilter.ToolTip = null;
            this.scaFilter.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.scaFilter.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.scaFilter_Execute);
            // 
            // VCConsultRecordList
            // 
            this.Actions.Add(this.scaFilter);
            this.TargetObjectType = typeof(Wendy.Module.BusinessObjects.ConsultRecord);
            this.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
            this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction scaFilter;
    }
}
