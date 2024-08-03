using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.BaseClasses.TripHandler;
using System.Collections.ObjectModel;

namespace Haulage.DatabaseExecutionServices
{

    public class AdminExecutionService
    {

        public static ObservableCollection<BaseClasses.BillingHandler.Billing> CustomerBills
        {
            get
            {
                return GetCustomerBills(1);
            }
        }
        public static ObservableCollection<BaseClasses.BillingHandler.Billing> GetCustomerBills(int customerId)
        {

            var customerItems = new List<BaseClasses.BillingHandler.Billing>();
            var sql = "SELECT [Bill].[BillId], [Bill].[UserId], [Bill].[ItemId], [Bill].[Status], [Bill].[TotalAmount], [User].[FullName] FROM [User], [Bill] WHERE [Bill].[UserId]=";
            sql = sql + customerId + " AND [Bill].[UserId] = [User].[UserId];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                customerItems = command.ExecuteQuery<BaseClasses.BillingHandler.Billing>();
            }
            ObservableCollection<BaseClasses.BillingHandler.Billing> newItems = new ObservableCollection<BaseClasses.BillingHandler.Billing>(customerItems);
            return newItems;
        }
    }
}
