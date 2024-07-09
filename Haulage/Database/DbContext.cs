using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using SQLite;

namespace Haulage.Database
{
    public class DbContext
    {
        public SQLiteConnection connection;

        public DbContext() { }

        public void Init()
        {
            string databasePath = Constants.DatabasePath;
            if (connection is not null)
            {
                return;
            }
            connection = new SQLiteConnection(databasePath, Constants.Flags);
            connection.CreateTable<Customer>();
        }
    }
}
