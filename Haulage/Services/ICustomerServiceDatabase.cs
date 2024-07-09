using Haulage.BaseClasses.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.Services
{
    public interface ICustomerServiceDatabase
    {
        List<Customer> GetItems();
        Customer GetItem(int id);
        int SaveItem(Customer item);
        int DeleteItem(Customer item);
    }
}
