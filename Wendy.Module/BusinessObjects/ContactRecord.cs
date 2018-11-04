using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace Wendy.Module.BusinessObjects
{
    public class ContactRecord : BaseObject
    {
        public ContactRecord(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            if (Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId) != null)
            {
                Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
                Recorder = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            }

            dt_CreateDate = DateTime.Now;
            dt_RecordDate = DateTime.Now;
            dt_NextDate = DateTime.Today;
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (StudentInfo?.ContactRecords != null)
            {
                StudentInfo.LastContactRecord = StudentInfo.ContactRecords.OrderByDescending(r => r.dt_NextDate).FirstOrDefault();
            }
        }

        private StudentInfo studentInfo;
        [Persistent("g_StudentInfoId"), Association("StudentInfo-ContactRecords")]
        public StudentInfo StudentInfo
        {
            get => studentInfo;
            set => SetPropertyValue("StudentInfo", ref studentInfo, value);
        }

        private DateTime _dtRecordDate;
        public DateTime dt_RecordDate
        {
            get => _dtRecordDate;
            set => SetPropertyValue("dt_RecordDate", ref _dtRecordDate, value);
        }

        private DateTime _dtNextDate;
        public DateTime dt_NextDate
        {
            get => _dtNextDate;
            set => SetPropertyValue("dt_NextDate", ref _dtNextDate, value);
        }

        private string _sContent;
        [Size(1000)]
        public string s_Content
        {
            get => _sContent;
            set => SetPropertyValue("s_Content", ref _sContent, value);
        }

        private SysUser recorder;
        [Persistent("g_RecorderId")]
        public SysUser Recorder
        {
            get => recorder;
            set => SetPropertyValue("Recorder", ref recorder, value);
        }

        private SysUser creator;
        [Persistent("g_CreatorId")]
        public SysUser Creator
        {
            get => creator;
            set => SetPropertyValue("Creator", ref creator, value);
        }

        private DateTime _dtCreateDate;
        public DateTime dt_CreateDate
        {
            get => _dtCreateDate;
            set => SetPropertyValue("dt_CreateDate", ref _dtCreateDate, value);
        }
    }
}