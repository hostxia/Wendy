using System;
using System.Configuration;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using Wendy.Module.BusinessObjects;
using Wendy.Module.Win;

namespace Wendy.Win {
	public partial class WendyWindowsFormsApplication : WinApplication, IApplicationFactory {
		protected override void ReadLastLogonParametersCore(DevExpress.ExpressApp.Utils.SettingsStorage storage, object logonObject) {
			AuthenticationStandardLogonParameters standardLogonParameters = logonObject as AuthenticationStandardLogonParameters;
			if((standardLogonParameters != null) && string.IsNullOrEmpty(standardLogonParameters.UserName)) {
				base.ReadLastLogonParametersCore(storage, logonObject);
			}
		}
		protected override void OnLoggingOn(LogonEventArgs args) {
			base.OnLoggingOn(args);
			MSSqlServerChangeDatabaseHelper.UpdateDatabaseName(this, ((IDatabaseNameParameter)args.LogonParameters).DatabaseName);
		}
		protected override bool OnLogonFailed(object logonParameters, Exception e) {
			if(WinChangeDatabaseHelper.SkipLogonDialog) {
				return true;
			}
			return base.OnLogonFailed(logonParameters, e);
		}
		WinApplication IApplicationFactory.CreateApplication() {
			return CreateApplication();
		}
		public static WendyWindowsFormsApplication CreateApplication() {
		    WendyWindowsFormsApplication winApplication = new WendyWindowsFormsApplication();

			((SecurityStrategyComplex)winApplication.Security).Authentication = new WinChangeDatabaseStandardAuthentication();

			//WinChangeDatabaseActiveDirectoryAuthentication activeDirectoryAuthentication = new WinChangeDatabaseActiveDirectoryAuthentication();
			//activeDirectoryAuthentication.CreateUserAutomatically = true;
			//((SecurityStrategyComplex)winApplication.Security).Authentication = activeDirectoryAuthentication;

			if(ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
				winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
			return winApplication;
		}
	}
}
