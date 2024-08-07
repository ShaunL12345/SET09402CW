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
        public static List<Item> GetItems()
        {
            var items = new List<Item>();
            var sql = "SELECT [ItemID], [Name], [Description], [ItemCategory], [SignedOff] FROM [Item];";

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
        public static void SaveVehicle(Vehicle vehicle)
        {
            var sql = $"Insert into [Vehicle] ([VehicleId], [tripID], [LicensePlate], [Capacity], [DriverId], [Status]) VALUES ({vehicle.VehicleId},{vehicle.tripID},'{vehicle.LicensePlate}',{vehicle.Capacity},{vehicle.DriverId},'{vehicle.Status}');";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}
