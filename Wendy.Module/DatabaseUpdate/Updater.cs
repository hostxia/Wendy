using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using Wendy.Module.BusinessObjects;

namespace Wendy.Module.DatabaseUpdate
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion)
        {
        }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
            SysUser sampleUser = ObjectSpace.FindObject<SysUser>(new BinaryOperator("UserName", "User"));
            if (sampleUser == null)
            {
                sampleUser = ObjectSpace.CreateObject<SysUser>();
                sampleUser.UserName = "User";
                sampleUser.SetPassword("");
            }
            PermissionPolicyRole defaultRole = CreateDefaultRole();
            sampleUser.Roles.Add(defaultRole);

            SysUser userAdmin = ObjectSpace.FindObject<SysUser>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<SysUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            PermissionPolicyRole adminRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
            userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges(); //This line persists created object(s).

            //UpdateStudentInfo();
            //ImportData();
            //UpdateCurrentCount();
        }

        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        private PermissionPolicyRole CreateDefaultRole()
        {
            PermissionPolicyRole defaultRole = ObjectSpace.FindObject<PermissionPolicyRole>(new BinaryOperator("Name", "Default"));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectPermission<SysUser>(SecurityOperations.Read, "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddNavigationPermission(@"Application/NavigationItems/Items/Default/Items/MyDetails", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermission<SysUser>(SecurityOperations.Write, "ChangePasswordOnFirstLogon", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddMemberPermission<SysUser>(SecurityOperations.Write, "StoredPassword", "[Oid] = CurrentUserId()", SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.Read, SecurityPermissionState.Deny);
                defaultRole.AddTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
                defaultRole.AddTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecurityPermissionState.Allow);
            }
            return defaultRole;
        }

        public void UpdateCurrentCount()
        {
            ObjectSpace.GetObjects<SourseInfo>().ToList().ForEach(s =>
            {
                s.CalculateCurrentCount();
                s.Save();
                ObjectSpace.CommitChanges();
            });
            ObjectSpace.GetObjects<DemoInfo>().ToList().ForEach(s =>
            {
                s.CalculateCurrentCount();
                s.Save();
                ObjectSpace.CommitChanges();
            });
        }
        public void UpdateStudentInfo()
        {
            var listStudentInfo = ObjectSpace.GetObjects<StudentInfo>();
            foreach (var studentInfo in listStudentInfo)
            {
                var consultRecord = studentInfo.ConsultRecords.FirstOrDefault();
                //if (consultRecord != null && consultRecord.Consultant != null)
                //{
                //    //studentInfo.OwnerCC = consultRecord.Consultant;
                //    ObjectSpace.CommitChanges();
                //}
            }
        }

        public void ImportData()
        {
            DataTable dtExcel = new DataTable();
            LoadExcel(@"C:\Users\Xiameng\Desktop\import1.xlsx", "新生表", ref dtExcel);
            foreach (DataRow dataRow in dtExcel.Rows)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(dataRow["联系电话"]?.ToString()))
                    {
                        continue;
                    }

                    var studentInfo = ObjectSpace.CreateObject<StudentInfo>();
                    var arrayPhone = dataRow["联系电话"].ToString().Split('/');
                    studentInfo.s_Phone = arrayPhone[0];
                    if (studentInfo.s_Phone.Length < 11)
                    {
                        studentInfo.s_Phone = studentInfo.s_Phone.PadLeft(11, '0');
                    }

                    if (arrayPhone.Length > 1)
                    {
                        studentInfo.s_Phone2 = arrayPhone[1];
                    }

                    studentInfo.s_Parent = dataRow["联系人"]?.ToString();
                    studentInfo.s_Name = dataRow["姓名"]?.ToString();
                    studentInfo.s_Sex = dataRow["性别"]?.ToString()?.Trim();
                    int.TryParse(dataRow["年龄"].ToString(), out var nAge);
                    studentInfo.dt_BirthDate = DateTime.Today.AddYears(0 - nAge);
                    studentInfo.s_Ability = dataRow["基础"]?.ToString();
                    studentInfo.s_Character = dataRow["性格"]?.ToString().Length >10?string.Empty: dataRow["性格"]?.ToString();
                    studentInfo.s_Address = dataRow["住址"]?.ToString();
                    studentInfo.s_School = dataRow["幼儿园/小学"]?.ToString();
                    studentInfo.s_Train = dataRow["兴趣班"]?.ToString();
                    //studentInfo.s_Valid = dataRow["有效"]?.ToString();

                    var consultRecord = studentInfo.ConsultRecords.Count > 0
                        ? studentInfo.ConsultRecords[0]
                        : ObjectSpace.CreateObject<ConsultRecord>();
                    consultRecord.StudentInfo = studentInfo;
                    consultRecord.s_Level = dataRow["级别"]?.ToString();
                    studentInfo.s_Source = dataRow["来源"]?.ToString();
                    //consultRecord.s_Status = dataRow["状态"]?.ToString();
                    consultRecord.s_Demand = dataRow["需求"]?.ToString();
                    //if (!string.IsNullOrWhiteSpace(dataRow["课程顾问"]?.ToString()))
                    //{
                    //    consultRecord.Consultant = ObjectSpace.FindObject<SysUser>(
                    //    CriteriaOperator.Parse($"s_Name like '%{dataRow["课程顾问"]}%' or s_EName like '%{dataRow["课程顾问"]}%'"));
                    //}

                    var contactRecord = studentInfo.ContactRecords.Count > 0
                        ? studentInfo.ContactRecords[0]
                        : ObjectSpace.CreateObject<ContactRecord>();

                    if (!string.IsNullOrWhiteSpace(dataRow["咨询日期"]?.ToString()))
                    {
                        consultRecord.dt_ConsultDate = Convert.ToDateTime(dataRow["咨询日期"].ToString().Replace("号","日"));
                        contactRecord.dt_RecordDate = consultRecord.dt_ConsultDate;
                    }

                    if (!string.IsNullOrWhiteSpace(dataRow["预计回访日期"]?.ToString()))
                    {
                        DateTime.TryParse(dataRow["预计回访日期"].ToString(), out var dtDate);
                        contactRecord.dt_NextDate = dtDate;
                        contactRecord.s_Content = dataRow["上门日期"].ToString();
                    }
                    //studentInfo.OwnerCC = consultRecord.Consultant;
                    ObjectSpace.CommitChanges();
                }
                catch (Exception e)
                {
                    ObjectSpace.Rollback();
                    Console.WriteLine(e);
                }
            }
        }

        public static void LoadExcel(string sFilePath, string sSheetName, ref DataTable dtExcelData)
        {
            var sConnectionString =
                $"Provider=Microsoft.Ace.OleDb.12.0;data source={sFilePath};Extended Properties='Excel 12.0;'";
            using (var conn = new OleDbConnection(sConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from [" + sSheetName + "$]";
                    var ds = new DataSet();
                    using (var da = new OleDbDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        dtExcelData = ds.Tables[0];
                    }
                }
            }
        }
    }
}
