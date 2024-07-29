using Haulage.BaseClasses.Accounting;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.DatabaseExecutionServices
{
    public static class CustomerExecutionService
    {
        public static List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            var sql = "SELECT [UserId]" +
                ",[Fullname]" +
                ",[Email]" +
                ",[PhoneNumber]" +
                ",[UserRole]" +
                ",[Address]" +
                ",[Qualification]" +
                $"FROM [User] WHERE [UserRole] = '{Role.customer.ToString()}' ;";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                customers = command.ExecuteQuery<Customer>();
            }

            return customers;
        }
        public static void deleteCustomer(int UserId)
        {
            var sql = $"DELETE FROM [User] WHERE [UserId] = {UserId};";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

        }

        public static void SaveCustomer(Customer customer)
        {
            var sql = $"INSERT INTO [User] ([UserId], [Fullname], [Email], [PhoneNumber], [UserRole], [Address], [Qualification]) VALUES ('{customer.UserId}','{customer.Fullname}', '{customer.Email}', '{customer.PhoneNumber}', '{customer.UserRole}','{customer.Address}','{customer.Qualification}');";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}
