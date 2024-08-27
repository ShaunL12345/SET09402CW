using System;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModels;
using Haulage.AdminPages;
using Haulage.BaseClasses.TripHandler;
using Haulage;
namespace HaulageTests
{

    /// <summary>
    /// 
    /// </summary>
    [CollectionDefinition("DatabaseTests", DisableParallelization = true)]
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
        public void PickupItemTest() 
        {
            DatabaseSetup.InitializeDatabase();
            var items = ItemExecutionService.GetItems();
            Assert.NotNull(items);
            Assert.True(items.Count > 0,"there were no items gotten from the database");
            var item = items[0];
            ItemExecutionService.PickupItem(item.ItemId);
            var updatedItem = ItemExecutionService.GetItem(item.ItemId);
            Assert.Equal(PickupRequest.requestStatus.EnRouteToPickup,updatedItem.RequestStatus);
        }

        [Fact]
        public void DropOffItem()
        {
            DatabaseSetup.InitializeDatabase();
            var items = ItemExecutionService.GetItems();
            Assert.NotNull(items);
            Assert.True(items.Count > 0, "there were no items gotten from the database");
            var item = items[0];
            ItemExecutionService.DropOffItem(item.ItemId);
            var updatedItem = ItemExecutionService.GetItem(item.ItemId);
            Assert.Equal(PickupRequest.requestStatus.droppedoff, updatedItem.RequestStatus);
        }
    }
}