using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModel;
using Haulage.AdminPages;
namespace HaulageTests
{

    /// <summary>
    /// 
    /// </summary>
    public class AdminManageCustomerBillTest
    {
        [Fact]
        public void GetCustomerBillsFromDatabase()
        {
            DatabaseSetup.InitializeDatabase();
            var customerbills = AdminExecutionService.GetCustomerBills(1);
            Assert.NotNull(customerbills);
            Assert.True(customerbills.Count > 0, "Did not recieve any records from GetCustomerItems method");
        }


    }
}
