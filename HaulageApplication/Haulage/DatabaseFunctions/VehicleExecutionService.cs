using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;

namespace Haulage.DatabaseFunctions
{
    public static class VehicleExecutionService
    {
        public static List<Vehicle> getVehicles() 
        {
            var vehicles = new List<Vehicle>();
            var sql = "SELECT [VehicleId]" +
                ",[tripID]    " +
                ",[LicensePlate]     " +
                ",[Capacity]      " +
                ",[DriverId]  " +
                ",[Status]  " +
                "FROM [Vehicle];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                vehicles = command.ExecuteQuery<Vehicle>();
            }
            return vehicles;
        }
    }
}
