using Haulage.DatabaseExecutionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Haulage.ViewModels
{
    
    public class CustomerItemView
    {
        private int customerid;
        public int CustomerId { get { return customerid; } 
            set { 
                customerid = value;
                CustomerItems.Clear();
                var itemObjects = CustomerExecutionService.GetCustomerItems(this.customerid);
                foreach (var itemObject in itemObjects)
                {
                    CustomerItems.Add(itemObject);
                }
            } 
        }
        public ObservableCollection<BaseClasses.TripHandler.Item> CustomerItems { get; set; }

        public CustomerItemView()
        {
            
            
            CustomerItems = new ObservableCollection<BaseClasses.TripHandler.Item>();
            CustomerId = -1;

        }
    }
}
