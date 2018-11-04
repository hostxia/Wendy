using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.Xpo;
using Wendy.Module.BusinessObjects;

namespace Wendy.Win
{
    public class ExtSecuredObjectSpaceProvider : SecuredObjectSpaceProvider
    {
        public ExtSecuredObjectSpaceProvider(ISelectDataSecurityProvider selectDataSecurityProvider, string databaseConnectionString, IDbConnection connection) : base(selectDataSecurityProvider, databaseConnectionString, connection)
        {
        }

        protected override UnitOfWork CreateDirectUnitOfWork(IDataLayer dataLayer)
        {
            UnitOfWork directBaseUow = base.CreateDirectUnitOfWork(dataLayer);
            directBaseUow.Disposed += new EventHandler(directBaseUow_Disposed);
            directBaseUow.BeforeCommitTransaction += new SessionManipulationEventHandler(directBaseUow_BeforeCommitTransaction);
            return directBaseUow;
        }

        private void directBaseUow_Disposed(object sender, EventArgs e)
        {
            UnitOfWork directBaseUow = (UnitOfWork)sender;
            directBaseUow.Disposed -= new EventHandler(directBaseUow_Disposed);
            directBaseUow.BeforeCommitTransaction -= new SessionManipulationEventHandler(directBaseUow_BeforeCommitTransaction);
        }

        private void directBaseUow_BeforeCommitTransaction(object sender, SessionManipulationEventArgs e)
        {
            var listDemo = new List<DemoInfo>();
            var listSource = new List<SourseInfo>();
            foreach (var item in e.Session.GetObjectsToSave())
            {
                switch (item)
                {
                    case DemoInfo demoInfo:
                        {
                            if (!listDemo.Contains(demoInfo))
                            {
                                listDemo.Add(demoInfo);
                            }

                            break;
                        }
                    case SourseInfo sourseInfo:
                        {
                            if (!listSource.Contains(sourseInfo))
                            {
                                listSource.Add(sourseInfo);
                            }

                            break;
                        }
                    case ConsultRecord consultRecord:
                        {
                            if (consultRecord.DemoInfo != null && !listDemo.Contains(consultRecord.DemoInfo))
                            {
                                listDemo.Add(consultRecord.DemoInfo);
                            }
                            if (consultRecord.SourseInfo != null && !listSource.Contains(consultRecord.SourseInfo))
                            {
                                listSource.Add(consultRecord.SourseInfo);
                            }

                            break;
                        }
                }
            }

            foreach (var demoInfo in listDemo)
            {
                demoInfo.CalculateCurrentCount();
            }
            foreach (var sourseInfo in listSource)
            {
                sourseInfo.CalculateCurrentCount();
            }
        }
    }
}
