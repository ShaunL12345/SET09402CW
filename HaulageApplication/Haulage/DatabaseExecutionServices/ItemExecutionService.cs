using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.BaseClasses.TripHandler;

namespace Haulage.DatabaseExecutionServices
{
    public static class ItemExecutionService
    {
        public static void SetItemToDropOff(int itemID)
        {
            var sql = $"UPDATE [Item] SET [RequestStatus] = '{PickupRequest.requestStatus.droppedoff}' WHERE ItemID={itemID};";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }

        public static void pickupItem(int itemID) 
        {
            var sql = $"UPDATE [Item] SET [RequestStatus] = '{PickupRequest.requestStatus.EnRouteToPickup}' WHERE ItemID={itemID};";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }

        public static List<Item> GetItems()
        {
            var items = new List<Item>();
            var sql = $"SELECT [ItemID], [Name], [Description], [ItemCategory], [SignedOff], [RequestStatus] FROM [Item] WHERE [RequestStatus] <> '{PickupRequest.requestStatus.droppedoff}';";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                items = command.ExecuteQuery<Item>();
            }
            return items;
        }
        public static void DeleteItem(int itemID)
        {
            var sql = $"DELETE FROM [Item] WHERE [ItemID] = {itemID};";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

        }
    }
}
