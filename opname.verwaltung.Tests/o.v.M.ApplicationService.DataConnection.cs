using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace opname.verwaltung.Tests
{
    using Management.ApplicationServices.DataConnection.MongoDB;
    using opname.verwaltung.Management.Domain;
    [TestClass]
    public class o_v_M_ApplicationService_DataConnection
    {
        private DataStorage dataContext;
        [TestMethod]
        public void ConnectToAWSMongoDB()
        {
            bool success = true;
            try
            {
            dataContext = new DataStorage() { Record = new AuditRecord() { AreaAccessed = "http://...", AuditID = new Guid(), IPAddress = "1.1.1.1", Timestamp = DateTime.Now, UserName = "abc" } };
            
            dataContext.Insert();
            }
            catch
            {
                success = false;
                
            }

            Assert.IsTrue(success, "No Exception Thrown");
            
        }
    }
}
