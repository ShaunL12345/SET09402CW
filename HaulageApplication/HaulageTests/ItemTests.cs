using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModels;
using Haulage.AdminPages;
namespace HaulageTests
{

    /// <summary>
    /// 
    /// </summary>
    public class ItemTests
    {
        [Fact]
        public void getItemsFromDatabase()
        {
            DatabaseSetup.InitializeDatabase();
            var items = ItemExecutionService.GetItems();
            Assert.NotNull(items);
            Assert.True(items.Count > 0, "Did not recieve any records from GetCustomerItems method");
        }

        [Fact]
        public void deleteItemFromDatabse() 
        {

        }
   
    }
}