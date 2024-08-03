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

        public int BillId { get; set; }
        public Billingstatus Status { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public string FullName { get; set; }

        public decimal TotalAmount { get; set; }



        public enum Billingstatus
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
