using DevExpress.ExpressApp;
using System;
using System.Linq;
using System.Windows.Forms;
using Wendy.Module.BusinessObjects;

namespace Wendy.Module.Win.Form
{
    public partial class XFrmDistribution : DevExpress.XtraEditors.XtraForm
    {
        public SysUser FilterUser;
        public SysUser InviteUser;
        public XFrmDistribution(IObjectSpace objectSpace)
        {
            InitializeComponent();
            xslueFilterUser.Properties.DataSource = xslueInviteUser.Properties.DataSource =
                objectSpace.GetObjectsQuery<SysUser>().ToList();
        }

        private void xsbClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void xsbCheck_Click(object sender, EventArgs e)
        {
            FilterUser = xslueFilterUser.EditValue as SysUser;
            InviteUser = xslueInviteUser.EditValue as SysUser;
            DialogResult = DialogResult.OK;
        }
    }
}