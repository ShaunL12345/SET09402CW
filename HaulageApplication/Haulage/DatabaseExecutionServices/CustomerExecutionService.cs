using Haulage.BaseClasses.Accounting;
using SQLite;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.TripHandler;
using System.Collections.ObjectModel;
using Haulage.BaseClasses;

namespace Haulage.DatabaseExecutionServices
{

    public class CustomerExecutionService
    {

        public static ObservableCollection<BaseClasses.TripHandler.Item> CustomerItems
        {
            get
            {
                return GetCustomerItems(1);
            }
        }
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


