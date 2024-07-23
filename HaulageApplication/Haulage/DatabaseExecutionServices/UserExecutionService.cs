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
        public static List<Driver> GetDrivers()
        {
            var drivers = new List<Driver>();
            var sql = "SELECT [Id]" +
                ",[Name]    " +
                ",[Email]     " +
                ",[PhoneNumber]      " +
                ",[Role]  " +
                ",[Address]  " +
                ",[Qualification] " +
                "FROM [User];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                drivers = command.ExecuteQuery<Driver>();
            }
            return drivers;
        }

        public static List<AddEmployee> GetAddDrivers()
        {
            var addEmployees = new List<AddEmployee>();
            var sql = "SELECT [Id]" +
                ",[Name]    " +
                ",[Email]     " +
                ",[PhoneNumber]      " +
                ",[Role]  " +
                ",[Address]  " +
                ",[Qualification] " +
                "FROM [User];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                addEmployees = command.ExecuteQuery<AddEmployee>();
            }
            return addEmployees;
        }
    }
}