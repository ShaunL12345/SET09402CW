using Haulage.BaseClasses.Accounting;
using Haulage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.Services
{
    public class CustomerServiceDatabase : ICustomerServiceDatabase
    {
        public DbContext _dbContext;
        public CustomerServiceDatabase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int DeleteItem(Customer item)
        {
            _dbContext.Init();
            return _dbContext.connection.Delete(item);
        }

        public List<Customer> GetItems()
        {
            _dbContext.Init();
            return _dbContext.connection.Table<Customer>().ToList();
        }

        public Customer GetItem(string id)
        {
            _dbContext.Init();
            return _dbContext.connection.Table<Customer>().Where(i => i.id.ToString() == id).FirstOrDefault();
        }

        public int SaveItem(Customer item)
        {
            _dbContext.Init();
            if (string.IsNullOrEmpty(item.id.ToString()))
                return _dbContext.connection.Update(item);
            else
                return _dbContext.connection.Insert(item);
        }
    }
}
