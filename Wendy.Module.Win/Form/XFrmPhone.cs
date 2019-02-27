using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using Wendy.Module.BusinessObjects;

namespace Wendy.Module.Win.Form
{
    public partial class XFrmPhone : DevExpress.XtraEditors.XtraForm
    {
        private readonly IObjectSpace _objectSpace;
        public StudentInfo StudentInfo;
        public string PhoneCode => xtePhone.Text.Trim();
        public XFrmPhone(IObjectSpace objectSpace)
        {
            InitializeComponent();
            _objectSpace = objectSpace;
        }

        private void xsbClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void xsbCheck_Click(object sender, EventArgs e)
        {
            StudentInfo = _objectSpace.GetObjectsQuery<StudentInfo>()
                .FirstOrDefault(r => r.s_Phone == xtePhone.Text.Trim() || r.s_Phone2 == xtePhone.Text.Trim());
            if (StudentInfo == null)
            {
                DialogResult = DialogResult.OK;
                return;
            }

            DialogResult = XtraMessageBox.Show("该手机号已在系统中存在，是否继续创建？", "手机号重复", MessageBoxButtons.OKCancel);
        }
    }
}