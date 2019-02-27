using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Xpo.DB.Helpers;

namespace Wendy.Module.BusinessObjects
{
    public interface IDatabaseNameParameter
    {
        string DatabaseName { get; set; }
    }
    [DomainComponent]
    public class CustomLogonParametersForStandardAuthentication : AuthenticationStandardLogonParameters, IDatabaseNameParameter
    {
        private string databaseName = MSSqlServerChangeDatabaseHelper.Databases.Split(';')[0];
        [ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.Databases)]
        public string DatabaseName
        {
            get => databaseName;
            set => databaseName = value;
        }
    }
    [DomainComponent]
    public class CustomLogonParametersForActiveDirectoryAuthentication : IDatabaseNameParameter
    {
        private string databaseName = MSSqlServerChangeDatabaseHelper.Databases.Split(';')[0];

        [ModelDefault("PredefinedValues", MSSqlServerChangeDatabaseHelper.Databases)]
        public string DatabaseName
        {
            get => databaseName;
            set => databaseName = value;
        }
    }
    public class MSSqlServerChangeDatabaseHelper
    {
        public const string Databases = "校区1";
        public static void UpdateDatabaseName(XafApplication application, string databaseName)
        {
            ConnectionStringParser helper = new ConnectionStringParser(application.ConnectionString);
            //helper.RemovePartByName("DataBase");
            //helper.RemovePartByName("Password");
            //application.ConnectionString = string.Format("Password=Xiameng19870218;DataBase={0};{1}", "WendyDB", helper.GetConnectionString());
        }
    }
}
