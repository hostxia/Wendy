using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace Wendy.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("s_Name")]
    public class SourseInfo : BaseObject
    {
        public SourseInfo(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            if (Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId) != null)
            {
                Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            }

            dt_CreateDate = DateTime.Now;
            base.AfterConstruction();
        }

        private DateTime _dtOpenDate;
        public DateTime dt_OpenDate
        {
            get => _dtOpenDate;
            set => SetPropertyValue("dt_OpenDate", ref _dtOpenDate, value);
        }

        /// <summary>
        /// 上课时间
        /// </summary>
        private string _sClassTime;
        [Size(100)]
        public string s_ClassTime
        {
            get => _sClassTime;
            set => SetPropertyValue("s_ClassTime", ref _sClassTime, value);
        }


        /// <summary>
        /// 课程名称
        /// </summary>
        private string _sName;
        [Size(100)]
        public string s_Name
        {
            get => _sName;
            set => SetPropertyValue("s_Name", ref _sName, value);
        }

        /// <summary>
        /// 课程说明
        /// </summary>
        private string _sDescription;
        [Size(400)]
        public string s_Description
        {
            get => _sDescription;
            set => SetPropertyValue("s_Description", ref _sDescription, value);
        }

        /// <summary>
        /// 课程状态
        /// </summary>
        private string _sStatus;
        [Size(20)]
        public string s_Status
        {
            get => _sStatus;
            set => SetPropertyValue("s_Status", ref _sStatus, value);
        }

        /// <summary>
        /// 课程级别
        /// </summary>
        private string _sLevel;
        [RuleRequiredField]
        [RuleUniqueValue]
        public string s_Level
        {
            get => _sLevel;
            set => SetPropertyValue("s_Level", ref _sLevel, value);
        }

        /// <summary>
        /// 教室位置
        /// </summary>
        private string _sLocation;
        [Size(100)]
        public string s_Location
        {
            get => _sLocation;
            set => SetPropertyValue("s_Location", ref _sLocation, value);
        }

        /// <summary>
        /// 最大人数
        /// </summary>
        private int _nMaxNum;
        public int n_MaxNum
        {
            get => _nMaxNum;
            set => SetPropertyValue("n_MaxNum", ref _nMaxNum, value);
        }

        /// <summary>
        /// 老师
        /// </summary>
        private SysUser teacher1;
        [Persistent("g_Teacher1Id")]
        public SysUser Teacher1
        {
            get => teacher1;
            set => SetPropertyValue("Teacher1", ref teacher1, value);
        }

        /// <summary>
        /// 外教
        /// </summary>
        private SysUser teacher2;
        [Persistent("g_Teacher2Id")]
        public SysUser Teacher2
        {
            get => teacher2;
            set => SetPropertyValue("Teacher2", ref teacher2, value);
        }

        /// <summary>
        /// 助教1
        /// </summary>
        private SysUser teacher3;
        [Persistent("g_Teacher3Id")]
        public SysUser Teacher3
        {
            get => teacher3;
            set => SetPropertyValue("Teacher3", ref teacher3, value);
        }

        /// <summary>
        /// 助教2
        /// </summary>
        private SysUser teacher4;
        [Persistent("g_Teacher4Id")]
        public SysUser Teacher4
        {
            get => teacher4;
            set => SetPropertyValue("Teacher4", ref teacher4, value);
        }

        /// <summary>
        /// 助教3
        /// </summary>
        private SysUser teacher5;
        [Persistent("g_Teacher5Id")]
        public SysUser Teacher5
        {
            get => teacher5;
            set => SetPropertyValue("Teacher5", ref teacher5, value);
        }


        /// <summary>
        /// 助教4
        /// </summary>
        private SysUser teacher6;
        [Persistent("g_Teacher6Id")]
        public SysUser Teacher6
        {
            get => teacher6;
            set => SetPropertyValue("Teacher6", ref teacher6, value);
        }


        /// <summary>
        /// 备注
        /// </summary>
        private string _sNote;
        [Size(1000)]
        public string s_Note
        {
            get => _sNote;
            set => SetPropertyValue("s_Note", ref _sNote, value);
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

        [Persistent("n_CurrentCount")]
        private int _nCurrentCount;

        [PersistentAlias("_nCurrentCount")]
        public int n_CurrentCount => _nCurrentCount;

        public void CalculateCurrentCount()
        {
            _nCurrentCount = ConsultRecords.Count;
            OnChanged("n_CurrentCount");
        }


        public int n_RemainCount => n_MaxNum - n_CurrentCount;

        [Association("SourseInfo-ConsultRecords")]
        public XPCollection<ConsultRecord> ConsultRecords => GetCollection<ConsultRecord>("ConsultRecords");

        [Browsable(false)]
        [PersistentAlias("Concat(s_Name,'/',s_Level,'/',s_ClassTime)")]
        public string s_SourceInfo => EvaluateAlias("s_SourceInfo")?.ToString();
    }
}