using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.BaseClasses.TripHandler;
using System.Collections.ObjectModel;

namespace Haulage.DatabaseExecutionServices
{

    public class CustomerExecutionService
    {


        public static ObservableCollection<BaseClasses.TripHandler.Item> GetCustomerItems()
        {
            int customerId = 1;
            var customerItems = new List<BaseClasses.TripHandler.Item>();
            var sql = "SELECT [Item].[ItemID], [Item].[Name], [Item].[Description], [Item].[ItemCategory], [Item].[SignedOff] FROM [RequestPickup], [Item] WHERE [RequestPickup].[CustomerId]=";
            sql = sql + customerId + "AND [Item].[ItemID] = [RequestPickup].[ItemId];";
            
            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                customerItems = command.ExecuteQuery<BaseClasses.TripHandler.Item>();
            }
            ObservableCollection<BaseClasses.TripHandler.Item> newItems = new ObservableCollection<BaseClasses.TripHandler.Item>(customerItems);
            return newItems;
        }
    } 
}
