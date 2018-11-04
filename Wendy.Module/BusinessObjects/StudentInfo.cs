using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Wendy.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("s_Name")]
    public class StudentInfo : BaseObject
    {
        public StudentInfo(Session session)
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
            s_Valid = "待定";
            ContactRecords.Add(new ContactRecord(Session) { StudentInfo = this });
            ConsultRecords.Add(new ConsultRecord(Session) { StudentInfo = this });
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (ContactRecords != null)
            {
                LastContactRecord = ContactRecords.OrderByDescending(r => r.dt_NextDate).FirstOrDefault();
            }
        }

        /// <summary>
        /// 学生名称
        /// </summary>
        private string _sName;
        [Size(10)]
        [RuleRequiredField]
        public string s_Name
        {
            get => _sName;
            set => SetPropertyValue("s_Name", ref _sName, value);
        }

        /// <summary>
        /// 性别
        /// </summary>
        private string _sSex;
        [Size(1)]
        [RuleRequiredField]
        public string s_Sex
        {
            get => _sSex;
            set => SetPropertyValue("s_Sex", ref _sSex, value);
        }

        /// <summary>
        /// 性格
        /// </summary>
        private string _sCharacter;
        [Size(10)]
        public string s_Character
        {
            get => _sCharacter;
            set => SetPropertyValue("s_Character", ref _sCharacter, value);
        }

        /// <summary>
        /// 电话
        /// </summary>
        private string _sPhone;
        [Size(30)]
        public string s_Phone
        {
            get => _sPhone;
            set => SetPropertyValue("s_Phone", ref _sPhone, value);
        }

        /// <summary>
        /// 联系人
        /// </summary>
        private string _sParent;
        [Size(10)]
        public string s_Parent
        {
            get => _sParent;
            set => SetPropertyValue("s_Parent", ref _sParent, value);
        }


        /// <summary>
        /// 电话2
        /// </summary>
        private string _sPhone2;
        [Size(30)]
        public string s_Phone2
        {
            get => _sPhone2;
            set => SetPropertyValue("s_Phone2", ref _sPhone2, value);
        }

        /// <summary>
        /// 联系人2
        /// </summary>
        private string _sParent2;
        [Size(10)]
        public string s_Parent2
        {
            get => _sParent2;
            set => SetPropertyValue("s_Parent2", ref _sParent2, value);
        }

        /// <summary>
        /// 住址
        /// </summary>
        private string _sAddress;
        [Size(50)]
        public string s_Address
        {
            get => _sAddress;
            set => SetPropertyValue("s_Address", ref _sAddress, value);
        }

        /// <summary>
        /// 学校
        /// </summary>
        private string _sSchool;
        [Size(50)]
        public string s_School
        {
            get => _sSchool;
            set => SetPropertyValue("s_School", ref _sSchool, value);
        }

        /// <summary>
        /// 培训
        /// </summary>
        private string _sTrain;
        [Size(50)]
        public string s_Train
        {
            get => _sTrain;
            set => SetPropertyValue("s_Train", ref _sTrain, value);
        }

        /// <summary>
        /// 基础
        /// </summary>
        private string _sAbility;
        [Size(50)]
        public string s_Ability
        {
            get => _sAbility;
            set => SetPropertyValue("s_Ability", ref _sAbility, value);
        }

        private DateTime _dtBirthDate;
        [RuleRequiredField]
        public DateTime dt_BirthDate
        {
            get => _dtBirthDate;
            set => SetPropertyValue("dt_BirthDate", ref _dtBirthDate, value);
        }

        /// <summary>
        /// 累计积分
        /// </summary>
        private int _nTotalPoints;
        public int n_TotalPoints
        {
            get => _nTotalPoints;
            set => SetPropertyValue("n_TotalPoints", ref _nTotalPoints, value);
        }


        public int n_Points => n_AvailablePoints - n_ConsumePoints;


        /// <summary>
        /// 积分等级
        /// </summary>
        private string _sPointLevel;
        [Size(10)]
        public string s_PointLevel
        {
            get => _sPointLevel;
            set => SetPropertyValue("s_PointLevel", ref _sPointLevel, value);
        }

        /// <summary>
        /// 推荐人数
        /// </summary>
        private int _nRecommandNum;
        public int n_RecommandNum
        {
            get => _nRecommandNum;
            set => SetPropertyValue("n_RecommandNum", ref _nRecommandNum, value);
        }

        /// <summary>
        /// 开课人数
        /// </summary>
        private int _nBeginningClassNum;
        public int n_BeginningClassNum
        {
            get => _nBeginningClassNum;
            set => SetPropertyValue("n_BeginningClassNum", ref _nBeginningClassNum, value);
        }

        /// <summary>
        /// 生效积分
        /// </summary>
        private int _nAvailablePoints;
        public int n_AvailablePoints
        {
            get => _nAvailablePoints;
            set => SetPropertyValue("n_AvailablePoints", ref _nAvailablePoints, value);
        }

        /// <summary>
        /// 兑换积分
        /// </summary>
        private int _nConsumePoints;
        public int n_ConsumePoints
        {
            get => _nConsumePoints;
            set => SetPropertyValue("n_ConsumePoints", ref _nConsumePoints, value);
        }
        #region 报名信息
        /// <summary>
        /// 身份证号
        /// </summary>
        private string _sIdNo;
        [Size(18)]
        public string s_IdNo
        {
            get => _sIdNo;
            set => SetPropertyValue("s_IdNo", ref _sIdNo, value);
        }

        /// <summary>
        /// 民族
        /// </summary>
        private string _sNation;
        [Size(10)]
        public string s_Nation
        {
            get => _sNation;
            set => SetPropertyValue("s_Nation", ref _sNation, value);
        }

        /// <summary>
        /// 身高
        /// </summary>
        private decimal _nStature;
        public decimal n_Stature
        {
            get => _nStature;
            set => SetPropertyValue("n_Stature", ref _nStature, value);
        }

        /// <summary>
        /// 体重
        /// </summary>
        private decimal _nWeight;
        public decimal n_Weight
        {
            get => _nWeight;
            set => SetPropertyValue("n_Weight", ref _nWeight, value);
        }

        /// <summary>
        /// 鞋码
        /// </summary>
        private decimal _nShoeSize;
        public decimal n_ShoeSize
        {
            get => _nShoeSize;
            set => SetPropertyValue("n_ShoeSize", ref _nShoeSize, value);
        }

        /// <summary>
        /// 健康状况
        /// </summary>
        private string _sPhysicalCondition;
        [Size(50)]
        public string s_PhysicalCondition
        {
            get => _sPhysicalCondition;
            set => SetPropertyValue("s_PhysicalCondition", ref _sPhysicalCondition, value);
        }

        /// <summary>
        /// 过敏
        /// </summary>
        private string _sAllergyCondition;
        [Size(50)]
        public string s_AllergyCondition
        {
            get => _sAllergyCondition;
            set => SetPropertyValue("s_AllergyCondition", ref _sAllergyCondition, value);
        }


        /// <summary>
        /// 监护人
        /// </summary>
        private string _sGuardianName;
        [Size(10)]
        public string s_GuardianName
        {
            get => _sGuardianName;
            set => SetPropertyValue("s_GuardianName", ref _sGuardianName, value);
        }

        /// <summary>
        /// 监护人身份证
        /// </summary>
        private string _sGuardianIdNo;
        [Size(10)]
        public string s_GuardianIdNo
        {
            get => _sGuardianIdNo;
            set => SetPropertyValue("s_GuardianIdNo", ref _sGuardianIdNo, value);
        }

        /// <summary>
        /// 监护人
        /// </summary>
        private string _sWeChat;
        [Size(10)]
        public string s_WeChat
        {
            get => _sWeChat;
            set => SetPropertyValue("s_WeChat", ref _sWeChat, value);
        }

        /// <summary>
        /// 开户行
        /// </summary>
        private string _sBankName;
        [Size(20)]
        public string s_BankName
        {
            get => _sBankName;
            set => SetPropertyValue("s_BankName", ref _sBankName, value);
        }

        /// <summary>
        /// 户名
        /// </summary>
        private string _sAccountName;
        [Size(20)]
        public string s_AccountName
        {
            get => _sAccountName;
            set => SetPropertyValue("s_AccountName", ref _sAccountName, value);
        }

        /// <summary>
        /// 卡号
        /// </summary>
        private string _sAccountNo;
        [Size(20)]
        public string s_AccountNo
        {
            get => _sAccountNo;
            set => SetPropertyValue("s_AccountNo", ref _sAccountNo, value);
        }
        #endregion

        /// <summary>
        /// 有效
        /// </summary>
        private string _sValid;
        [Size(10)]
        public string s_Valid
        {
            get => _sValid;
            set => SetPropertyValue("s_Valid", ref _sValid, value);
        }

        private SysUser ownerCC;
        [Persistent("g_OwnerCCId")]
        public SysUser OwnerCC
        {
            get => ownerCC;
            set => SetPropertyValue("OwnerCC", ref ownerCC, value);
        }

        private SysUser ownerTMK;
        [Persistent("g_OwnerTMKId")]
        public SysUser OwnerTMK
        {
            get => ownerTMK;
            set => SetPropertyValue("OwnerTMK", ref ownerTMK, value);
        }

        /// <summary>
        /// 退回
        /// </summary>
        private bool _bIsBack;
        public bool b_IsBack
        {
            get => _bIsBack;
            set => SetPropertyValue("b_IsBack", ref _bIsBack, value);
        }

        /// <summary>
        /// 来源
        /// </summary>
        private string _sSource;
        [Size(20)]
        [RuleRequiredField]
        public string s_Source
        {
            get => _sSource;
            set => SetPropertyValue("s_Source", ref _sSource, value);
        }

        /// <summary>
        /// 来源说明
        /// </summary>
        private string _sSourceComment;
        [Size(20)]
        public string s_SourceComment
        {
            get => _sSourceComment;
            set => SetPropertyValue("s_SourceComment", ref _sSourceComment, value);
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

        [Aggregated, Association("StudentInfo-ConsultRecords")]
        public XPCollection<ConsultRecord> ConsultRecords => GetCollection<ConsultRecord>("ConsultRecords");

        [Association("StudentInfo-RecommendRecords")]
        public XPCollection<ConsultRecord> RecommendRecords => GetCollection<ConsultRecord>("RecommendRecords");

        [Aggregated, Association("StudentInfo-ContactRecords")]
        public XPCollection<ContactRecord> ContactRecords => GetCollection<ContactRecord>("ContactRecords");


        private ContactRecord contactRecord;
        [Persistent("g_LastContactRecordId")]
        public ContactRecord LastContactRecord
        {
            get => contactRecord;
            set => SetPropertyValue("LastContactRecord", ref contactRecord, value);
        }

        public double n_Age => DateTime.Today.Year - _dtBirthDate.Year +
                                (DateTime.Today - _dtBirthDate.AddYears(DateTime.Today.Year - _dtBirthDate.Year))
                                .TotalDays / 365;

        public List<SourseInfo> ListSourseInfos =>
            ConsultRecords.Where(r => r.SourseInfo != null).Select(r => r.SourseInfo).ToList();

        [PersistentAlias("ConsultRecords.Min(dt_ConsultDate)")]
        public DateTime dt_FirstConsultDate
        {
            get => Convert.ToDateTime(EvaluateAlias("dt_FirstConsultDate"));
        }

    }
}