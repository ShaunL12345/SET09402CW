using Haulage.DatabaseExecutionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Haulage.ViewModels
{

    public class AdminManageCustomerBillView
    {
        private int customerid;
        public int CustomerId
        {
            get { return customerid; }
            set
            {
                customerid = value;
                CustomerBills.Clear();
                var itemObjects = AdminExecutionService.GetCustomerBills(this.customerid);
                foreach (var itemObject in itemObjects)
                {
                    CustomerBills.Add(itemObject);
                }
            }
        }
        public ObservableCollection<BaseClasses.BillingHandler.Billing> CustomerBills { get; set; }

        public AdminManageCustomerBillView()
        {


            CustomerBills = new ObservableCollection<BaseClasses.BillingHandler.Billing>();
            CustomerId = -1;

        }
    }
}
