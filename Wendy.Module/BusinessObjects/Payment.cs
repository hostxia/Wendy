using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Linq;
using DevExpress.Persistent.Base;

namespace Wendy.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Payment : BaseObject
    {
        public Payment(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            if (Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId) != null)
            {
                Creator = Session.GetObjectByKey<SysUser>(SecuritySystem.CurrentUserId);
            }

            dt_PaidDate = dt_CreateDate = DateTime.Now;
            base.AfterConstruction();
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            if (consultRecord != null)
            {
                consultRecord.n_PaidAmount = consultRecord.Payments.Sum(p => p.n_PaidAmount);
            }
        }

        private ConsultRecord _deleteConsultRecord;

        protected override void OnDeleting()
        {
            base.OnDeleting();
            _deleteConsultRecord = consultRecord;

        }

        protected override void OnDeleted()
        {
            base.OnDeleted();
            if (_deleteConsultRecord != null)
            {
                _deleteConsultRecord.n_PaidAmount = _deleteConsultRecord.Payments.Sum(p => p.n_PaidAmount);
            }
        }

        private ConsultRecord consultRecord;
        [Persistent("g_ConsultRecordId"), Association("ConsultRecord-Payments")]
        public ConsultRecord ConsultRecord
        {
            get => consultRecord;
            set => SetPropertyValue("ConsultRecord", ref consultRecord, value);
        }

        private DateTime _dtPaidDate;
        public DateTime dt_PaidDate
        {
            get => _dtPaidDate;
            set => SetPropertyValue("dt_PaidDate", ref _dtPaidDate, value);
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
        /// 支付金额
        /// </summary>
        private decimal _nPaidAmount;
        public decimal n_PaidAmount
        {
            get => _nPaidAmount;
            set => SetPropertyValue("n_PaidAmount", ref _nPaidAmount, value);
        }


        private SysUser reveiver;
        [Persistent("g_ReveiverId")]
        public SysUser Reveiver
        {
            get => reveiver;
            set => SetPropertyValue("Reveiver", ref reveiver, value);
        }

        /// <summary>
        /// 票号
        /// </summary>
        private string _sPayNo;
        [Size(20)]
        public string s_PayNo
        {
            get => _sPayNo;
            set => SetPropertyValue("s_PayNo", ref _sPayNo, value);
        }

        /// <summary>
        /// 备注
        /// </summary>
        private string _sNote;
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
    }
}