using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.TripHandler;
using Haulage.BaseClasses.Accounting;


namespace Haulage.DatabaseExecutionServices
{
    public static class DriverExecutionService
    {

        public static List<TripEvent> GetEvents()
        {
            var vehicles = new List<TripEvent>();
            var sql = "SELECT [EventId], [DriverId], [EventType], [Description] FROM [Event];";
        }
        
        public static List<Driver> GetDrivers()
        {
            var drivers = new List<Driver>();
            var sql = "SELECT [UserId]" +
                ",[Fullname]" +
                ",[Email]" +
                ",[PhoneNumber]" +
                ",[Role]" +
                ",[Address]" +
                ",[Qualification]" +
                $"FROM [User] WHERE [Role] = '{Role.driver.ToString()}' ;";

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
                drivers = command.ExecuteQuery<Driver>();
    

            return drivers;
        }
        
        public static void DeleteDriver(int UserId)
        {
            var drivers = new List<Driver>();
            var sql = $"DELETE FROM [User] WHERE [UserId] = {UserId};";


            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    

        public static void SaveDriver(Driver driver)
        {
            var sql = $"INSERT INTO [User] ([UserId], [Fullname], [Email], [PhoneNumber], [Role], [Address], [Qualification]) VALUES ('{driver.UserId}','{driver.Fullname}', '{driver.Email}', '{driver.PhoneNumber}', '{driver.UserRole}','{driver.Address}','{driver.Qualification}');";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }


        }
    }
}

