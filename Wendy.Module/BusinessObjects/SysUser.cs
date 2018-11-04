using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Xpo;
using System.ComponentModel;

namespace Wendy.Module.BusinessObjects
{
    [DefaultClassOptions]
    [MapInheritance(MapInheritanceType.OwnTable)]
    [DefaultProperty("s_Name")]
    public class SysUser : PermissionPolicyUser
    {
        public SysUser(Session session)
            : base(session)
        {
        }

        private string _sNo;
        public string s_No
        {
            get => _sNo;
            set => SetPropertyValue("s_No", ref _sNo, value);
        }

        private string _sName;
        public string s_Name
        {
            get => _sName;
            set => SetPropertyValue("s_Name", ref _sName, value);
        }

        private string _sEName;
        public string s_EName
        {
            get => _sEName;
            set => SetPropertyValue("s_EName", ref _sEName, value);
        }

        private string _sDepartment;
        public string s_Department
        {
            get => _sDepartment;
            set => SetPropertyValue("s_Department", ref _sDepartment, value);
        }
    }
}