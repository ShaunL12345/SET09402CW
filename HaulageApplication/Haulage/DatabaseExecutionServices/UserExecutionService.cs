using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;


namespace Haulage.DatabaseExecutionServices
{
    public static class UserExecutionService
    {
        public static List<Driver> GetDrivers(SQLiteConnection? connection = null)
        {
            var drivers = new List<Driver>();
            var sql = "SELECT [UserId]" +
                ",[RoleId]    " +
                ",[Fullname]    " +
                ",[Email]     " +
                ",[PhoneNumber]      " +
                ",[Role]  " +
                ",[Address]  " +
                ",[Qualification] " +
                "FROM [User];";

            if (connection == null)
            {
                using (connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
                {
                    var command = new SQLite.SQLiteCommand(connection);
                    command.CommandText = sql;
                    drivers = command.ExecuteQuery<Driver>();
                }

            }
            else
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                drivers = command.ExecuteQuery<Driver>();
            }
            return drivers;
        }
        public static void DeleteDriver(int UserId, SQLiteConnection? connection = null)
        {
            var drivers = new List<Driver>();
            var sql = $"DELETE FROM [User] WHERE [UserId] = {UserId};";

            if (connection == null)
            {
                using (connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
                {
                    var command = new SQLite.SQLiteCommand(connection);
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }


    }

}