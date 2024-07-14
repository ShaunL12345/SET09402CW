using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    //class to class to hold driver functionality (inherited from Person)
    public class Driver : Person
    {
        //enum to contain qualifications that a driver must have to make certain deliveries
        enum qualifications
        {
            fragileAllowed,
            qualification2,
            qualification3,
        }

        //methodfor driver to record trip expenses
        public void recordExpenses()
        {

        }

        //Method for driver to record trip delays
        public void reportDelays()
        {

        }

        //Method for driver to confirm a pickup or delivery
        public void confirmPickupOrDelivery()
        {

        }
    }

    
}
