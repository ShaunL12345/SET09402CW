using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.BillingHandler;


namespace Haulage.DatabaseExecutionServices
{
    public static class BillExecutionService
    {
        public static List<Billing> GetBills(SQLiteConnection? connection = null)
        {
            var bills = new List<Billing>();
            var sql = "SELECT [BillId]" +
                ",[Fullname]    " +
                ",[Email]     " +
                "FROM [Bill];";

            if (connection == null)
            {
                using (connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
                {
                    var command = new SQLite.SQLiteCommand(connection);
                    command.CommandText = sql;
                    bills = command.ExecuteQuery<Billing>();
                }

            }
            else
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                bills = command.ExecuteQuery<Billing>();
            }

            return bills;
        }

        public static void DeleteBill(int BillId, SQLiteConnection? connection = null)
        {
            var bills = new List<Billing>();
            var sql = $"DELETE FROM [Bill] WHERE [BillId] = {BillId}";

            if(connection == null)
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

        //Save Method
        
    }
}