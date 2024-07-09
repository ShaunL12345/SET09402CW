using Haulage.BaseClasses.Accounting;
using Haulage.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.Services
{
    public class CustomerServiceDatabase : IDatabaseService
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

        public Customer GetItem(int id)
        {
            _dbContext.Init();
            return _dbContext.connection.Table<Customer>().Where(i => i.Id == id).FirstOrDefault();
        }

        public int SaveItem(Customer item)
        {
            _dbContext.Init();
            if (item.Id == 0)
                return _dbContext.connection.Update(item);
            else
                return _dbContext.connection.Insert(item);
        }
    }
}
