using Haulage.BaseClasses.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.DatabaseExecutionServices;

namespace Haulage.Models
{
    public static class CustomerModel
    {
        public static List<Customer> Customers = CustomerExecutionService.GetCustomers();
    }
}
