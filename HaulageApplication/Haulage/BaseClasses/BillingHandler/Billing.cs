using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    //class to contain billing functionality
    public class Billing
    {
        //variables to contain billing details
        public Guid BillID;
        public Guid customerID;
        public float totalAmount;

        //enum to contain status of item / delivery payment
        enum Billingstatus
        {
            notPaid,
            paid

        }
        public Billing() { }

        //Methos to update status of billing (unpaid / paid)
        public void updateBillingStatus()
        {

        }
    }
}
