using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using Wendy.Module.BusinessObjects.Base;

namespace Wendy.Module.BusinessObjects
{
    [DomainComponent]
    [Serializable]
    public class ExtAuthenticationStandardLogonParameters : AuthenticationStandardLogonParameters
    {
        public EnumAll.DataBaseName DataBaseName { get; set; }
    }
}