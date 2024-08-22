using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModels;
using Haulage.AdminPages;
using Haulage;

namespace HaulageTests
{

    /// <summary>
    /// 
    /// </summary>
    public class CustomerTrackItemTest
    {
        [Fact]
        public void GetCustomerItemFromDatabase()
        {
            DatabaseSetup.InitializeDatabase();
            var customeritems = CustomerExecutionService.GetCustomerItems(1);
            Assert.NotNull(customeritems);
            Assert.True(customeritems.Count > 0, "Did not recieve any records from GetCustomerItems method");
        }
        
   
    }
}