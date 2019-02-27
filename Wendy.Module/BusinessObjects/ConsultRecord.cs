using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace Wendy.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty("dt_ConsultDate")]
    [Appearance("Today", TargetItems = "*", Context = "ListView", Criteria = "DemoInfo is not null And DemoInfo.dt_OpenDate <= Today() And IsNull(s_SignupResult,'') = '' And b_VisitResult != False", FontColor = "Red")]
    public class ConsultRecord : BaseObject
    {
        public ConsultRecord(Session session)
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
            dt_ConsultDate = DateTime.Now;
            base.AfterConstruction();
        }

        private StudentInfo studentInfo;
        [Persistent("g_StudentInfoId"), Association("StudentInfo-ConsultRecords")]
        public StudentInfo StudentInfo
        {
            get => studentInfo;
            set => SetPropertyValue("StudentInfo", ref studentInfo, value);
        }

        private SourseInfo sourseInfo;
        [Persistent("g_SourseInfoId"), Association("SourseInfo-ConsultRecords")]
        public SourseInfo SourseInfo
        {
            get => sourseInfo;
            set => SetPropertyValue("SourseInfo", ref sourseInfo, value);
        }

        private DemoInfo demoInfo;
        [Persistent("g_DemoInfoId"), Association("DemoInfo-ConsultRecords")]
        public DemoInfo DemoInfo
        {
            get => demoInfo;
            set => SetPropertyValue("DemoInfo", ref demoInfo, value);
        }

        private DateTime _dtConsultDate;
        public DateTime dt_ConsultDate
        {
            get => _dtConsultDate;
            set => SetPropertyValue("dt_ConsultDate", ref _dtConsultDate, value);
        }

        private DateTime _dtRegDate;
        public DateTime dt_RegDate
        {
            get => _dtRegDate;
            set => SetPropertyValue("dt_RegDate", ref _dtRegDate, value);
        }

        /// <summary>
        /// 级别
        /// </summary>
        private string _sLevel;
        [Size(2)]
        public string s_Level
        {
            get => _sLevel;
            set => SetPropertyValue("s_Level", ref _sLevel, value);
        }

        /// <summary>
        /// 来源
        /// </summary>
        private string _sSource;
        [Size(20)]
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
        /// 需求
        /// </summary>
        private string _sDemand;
        [Size(50)]
        public string s_Demand
        {
            get => _sDemand;
            set => SetPropertyValue("s_Demand", ref _sDemand, value);
        }

        #region 状态
        #region 筛选结果
        /// <summary>
        /// 筛选结果
        /// </summary>
        private bool? _bFilterResult;
        [CaptionsForBoolValues("有效", "无效")]
        public bool? b_FilterResult
        {
            get => _bFilterResult;
            set => SetPropertyValue("b_FilterResult", ref _bFilterResult, value);
        }

        private SysUser filterUser;
        [Persistent("g_FilterId")]
        public SysUser FilterUser
        {
            get => filterUser;
            set => SetPropertyValue("FilterUser", ref filterUser, value);
        }

        private DateTime _dtFilterDate;
        public DateTime dt_FilterDate
        {
            get => _dtFilterDate;
            set => SetPropertyValue("dt_FilterDate", ref _dtFilterDate, value);
        }
        #endregion

        #region 邀约结果
        /// <summary>
        /// 邀约结果
        /// </summary>
        private string _sInviteResult;
        public string s_InviteResult
        {
            get => _sInviteResult;
            set => SetPropertyValue("s_InviteResult", ref _sInviteResult, value);
        }

        private SysUser inviteUser;
        [Persistent("g_InviteUserId")]
        public SysUser InviteUser
        {
            get => inviteUser;
            set => SetPropertyValue("InviteUser", ref inviteUser, value);
        }

        private SysUser shareUser;
        [Persistent("g_ShareUserId")]
        public SysUser ShareUser
        {
            get => shareUser;
            set => SetPropertyValue("ShareUser", ref shareUser, value);
        }

        private DateTime _dtInviteDate;
        public DateTime dt_InviteDate
        {
            get => _dtInviteDate;
            set => SetPropertyValue("dt_InviteDate", ref _dtInviteDate, value);
        }
        #endregion

        #region 上门结果
        /// <summary>
        /// 上门结果
        /// </summary>
        private bool? _bVisitResult;
        [CaptionsForBoolValues("已上门", "承诺未上门")]
        public bool? b_VisitResult
        {
            get => _bVisitResult;
            set => SetPropertyValue("b_VisitResult", ref _bVisitResult, value);
        }

        private SysUser visitUser;
        [Persistent("g_VisitUserId")]
        public SysUser VisitUser
        {
            get => visitUser;
            set => SetPropertyValue("VisitUser", ref visitUser, value);
        }


        private DateTime _dtVisitDate;
        public DateTime dt_VisitDate
        {
            get => _dtVisitDate;
            set => SetPropertyValue("dt_VisitDate", ref _dtVisitDate, value);
        }
        #endregion

        #region 报名结果
        /// <summary>
        /// 报名结果
        /// </summary>
        private string _sSignupResult;
        public string s_SignupResult
        {
            get => _sSignupResult;
            set => SetPropertyValue("s_SignupResult", ref _sSignupResult, value);
        }

        private SysUser signupUser;
        [Persistent("g_SignupUserId")]
        public SysUser SignupUser
        {
            get => signupUser;
            set => SetPropertyValue("SignupUser", ref signupUser, value);
        }

        private DateTime _dtSignupDate;
        public DateTime dt_SignupDate
        {
            get => _dtSignupDate;
            set => SetPropertyValue("dt_SignupDate", ref _dtSignupDate, value);
        }
        #endregion
        #endregion

        public string s_Status
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_sSignupResult))
                    return _sSignupResult;
                if (_bVisitResult.HasValue)
                    return _bVisitResult.Value ? "已上门" : "承诺未上门";
                if (!string.IsNullOrWhiteSpace(_sInviteResult))
                    return _sInviteResult;
                if (_bFilterResult.HasValue)
                    return _bFilterResult.Value ? "有效" : "无效";

                return string.Empty;
            }
        }

        public bool b_Distribution => filterUser != null || inviteUser != null;

        /// <summary>
        /// 报名期数
        /// </summary>
        private string _sSignUpPeriod;
        [Size(20)]
        public string s_SignUpPeriod
        {
            get => _sSignUpPeriod;
            set => SetPropertyValue("s_SignUpPeriod", ref _sSignUpPeriod, value);
        }

        /// <summary>
        /// 付款方式
        /// </summary>
        private string _sPayWay;
        [Size(20)]
        public string s_PayWay
        {
            get => _sPayWay;
            set => SetPropertyValue("s_PayWay", ref _sPayWay, value);
        }

        /// <summary>
        /// 应付金额
        /// </summary>
        private decimal _nAmount;
        public decimal n_Amount
        {
            get => _nAmount;
            set => SetPropertyValue("n_Amount", ref _nAmount, value);
        }

        /// <summary>
        /// 已付金额
        /// </summary>
        private decimal _nPaidAmount;
        public decimal n_PaidAmount
        {
            get => _nPaidAmount;
            set => SetPropertyValue("n_PaidAmount", ref _nPaidAmount, value);
        }

        private SysUser recommender;
        [Persistent("g_RecommendUserId")]
        public SysUser Recommender
        {
            get => recommender;
            set => SetPropertyValue("Recommender", ref recommender, value);
        }

        private StudentInfo recommendParent;
        [Persistent("g_RecommendParentId")]
        [Association("StudentInfo-RecommendRecords")]
        public StudentInfo RecommendParent
        {
            get => recommendParent;
            set => SetPropertyValue("RecommendParent", ref recommendParent, value);
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

        #region 领取信息
        /// <summary>
        /// 已领教材
        /// </summary>
        private bool _bGetBook;
        public bool b_GetBook
        {
            get => _bGetBook;
            set => SetPropertyValue("b_GetBook", ref _bGetBook, value);
        }

        /// <summary>
        /// 已领校服
        /// </summary>
        private bool _bGetUniform;
        public bool b_GetUniform
        {
            get => _bGetUniform;
            set => SetPropertyValue("b_GetUniform", ref _bGetUniform, value);
        }

        /// <summary>
        /// 已领舞蹈服/跆拳道服
        /// </summary>
        private bool _bGetDress;
        public bool b_GetDress
        {
            get => _bGetDress;
            set => SetPropertyValue("b_GetDress", ref _bGetDress, value);
        }

        /// <summary>
        /// 已领书包
        /// </summary>
        private bool _bGetBag;
        public bool b_GetBag
        {
            get => _bGetBag;
            set => SetPropertyValue("b_GetBag", ref _bGetBag, value);
        }

        /// <summary>
        /// 保险
        /// </summary>
        private bool _bInsurance;
        public bool b_Insurance
        {
            get => _bInsurance;
            set => SetPropertyValue("b_Insurance", ref _bInsurance, value);
        }

        /// <summary>
        /// 其他
        /// </summary>
        private string _sGetOther;
        [Size(100)]
        public string s_GetOther
        {
            get => _sGetOther;
            set => SetPropertyValue("s_GetOther", ref _sGetOther, value);
        }
        #endregion

        #region 发票信息
        private DateTime _dtInvoiceDate;
        public DateTime dt_InvoiceDate
        {
            get => _dtInvoiceDate;
            set => SetPropertyValue("dt_InvoiceDate", ref _dtInvoiceDate, value);
        }

        private string _sInvoiceTitle;
        public string s_InvoiceTitle
        {
            get => _sInvoiceTitle;
            set => SetPropertyValue("s_InvoiceTitile", ref _sInvoiceTitle, value);
        }

        private string _sInvoiceNo;
        public string s_InvoiceNo
        {
            get => _sInvoiceNo;
            set => SetPropertyValue("s_InvoiceNo", ref _sInvoiceNo, value);
        }

        private string _sInvoiceContent;
        public string s_InvoiceContent
        {
            get => _sInvoiceContent;
            set => SetPropertyValue("s_InvoiceContent", ref _sInvoiceContent, value);
        }

        private decimal _nInvoiceAmount;
        public decimal n_InvoiceAmount
        {
            get => _nInvoiceAmount;
            set => SetPropertyValue("n_InvoiceAmount", ref _nInvoiceAmount, value);
        }
        #endregion

        [DevExpress.Xpo.Aggregated, Association("ConsultRecord-Payments")]
        public XPCollection<Payment> Payments => GetCollection<Payment>("Payments");

        public decimal n_UnpaidAmount => n_Amount - n_PaidAmount;
    }
}