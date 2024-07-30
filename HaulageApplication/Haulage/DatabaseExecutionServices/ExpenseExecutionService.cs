using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.BaseClasses.BillingHandler;

namespace Haulage.DatabaseExecutionServices
{
    public static class ExpenseExecutionService
    {
        public static List<Expense> GetExpenses()
        {
            var expenses = new List<Expense>();
            var sql = "SELECT [ExpenseId], [DriverId], [VehicleId], [Fullname], [Expense], [ExpenseDescription], [ExpenseCost] FROM [Expense];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                expenses = command.ExecuteQuery<Expense>();
            }
            return expenses;
        }
        public static void DeleteExpense(int expenseId)
        {
            var sql = $"DELETE FROM [Expense] WHERE [ExpenseId] = {expenseId};";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

        }
        public static void SaveExpense(Expense expense)
        {
            var sql = $"Insert into [Expense] ([ExpenseId], [DriverID], [VehicleId], [Fullname], [Expense], [ExpenseDescription], [ExpenseCost]) VALUES ({expense.expenseId},{expense.driverId},'{expense.vehicleId}',{expense.fullname},{expense.expense},'{expense.expenseDescription}', '{expense.exspenseCost}');";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}
