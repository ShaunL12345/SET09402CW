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

        public static ObservableCollection<BaseClasses.TripHandler.Item> CustomerItems { get {
                return GetCustomerItems(1);
            } }
        public static ObservableCollection<BaseClasses.TripHandler.Item> GetCustomerItems(int customerId)
        {
            
            var customerItems = new List<BaseClasses.TripHandler.Item>();
            var sql = "SELECT [Item].[ItemID], [Item].[Name], [Item].[Description], [Item].[ItemCategory], [Item].[SignedOff], [PickupRequest].[RequestStatus] FROM [PickupRequest], [Item] WHERE [PickupRequest].[CustomerId]=";
            sql = sql + customerId + " AND [Item].[ItemID] = [PickupRequest].[ItemId];";
            
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
