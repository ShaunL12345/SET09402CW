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
    public static class VehicleExecutionService
    {
        public static List<Vehicle> GetVehicles()
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
            };

            return vehicles;
        }
        public static void DeleteVehicle(int vehicleId)
        {
            var vehicles = new List<Vehicle>();
            var sql = $"DELETE FROM [Vehicle] WHERE [VehicleId] = {vehicleId};";


            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

        }
        public static void SaveVehicle(Vehicle vehicle)
        {
            var vehicles = new List<Vehicle>();
            var sql = $"Insert into [Vehicle]" +
            " ([VehicleId]" +
            ",[tripID]    " +
            ",[LicensePlate]     " +
            ",[Capacity]      " +
            ",[DriverId]  " +
            ",[Status])  " +
            $"VALUES ({vehicle.VehicleId},{vehicle.tripID},'{vehicle.LicensePlate}',{vehicle.Capacity},{vehicle.DriverId},'{vehicle.Status}');";


            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

        }
    }
}
