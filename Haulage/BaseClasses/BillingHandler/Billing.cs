using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    public class Billing
    {
        public Guid BillID;
        public Guid customerID;
        public float totalAmount;
        enum Billingstatus
        {
            notPaid,
            paid

        }
        public Billing() { }

        public void updateBillingStatus()
        {

        }
    }
}
