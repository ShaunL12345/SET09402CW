using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.TripHandler;
namespace Haulage.DatabaseExecutionServices
{
    public static class DriverExecutionService
    {

        public static List<TripEvent> GetEvents()
        {
            var vehicles = new List<TripEvent>();
            var sql = "SELECT [EventId], [DriverId], [EventType], [Description] FROM [Event];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                vehicles = command.ExecuteQuery<TripEvent>();
            }
            return vehicles;
        }


        public static void RaiseEvent(TripEvent evt) 
        {
            var sql = $"Insert into [Event] ([EventId], [DriverId], [TripId], [EventType]) VALUES ({evt.DriverId},{evt.TripId},'{evt.EventType}','{evt.Description}');";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}
