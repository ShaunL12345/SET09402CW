using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    //Class to contain the Billing functionality of the application
    public class Billing
    {
        //Variables to contain billing attributes
        public Guid BillID;
        public Guid customerID;
        public float totalAmount;

        //Enum to contain the current status of a customers bill
        enum Billingstatus
        {
            notPaid,
            paid

        }

        public Billing() { }

        //Method to allow users to update billing status (paid / not paid)
        public void updateBillingStatus()
        {

        }
    }
}
