using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    //Class to contain Driver functionality of the application (inherit from Person class)
    public class Driver : Person
    {
        //Enum to contain the qualifications held by drivers
        enum qualifications
        {
            fragileAllowed,
            qualification2,
            qualification3,
        }

        //Method to allow drivers to record expenses
        public void recordExpenses()
        {

        }

        //Method to allow drivers to report delays in pickups or deliveries 
        public void reportDelays()
        {

        }

        //Method to allow drivers to confirm pickups or deliveries
        public void confirmPickupOrDelivery()
        {

        }
    }

    
}
