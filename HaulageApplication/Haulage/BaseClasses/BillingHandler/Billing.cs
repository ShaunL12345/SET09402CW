using Haulage.BaseClasses.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.BillingHandler
{
    public class Billing
    {
       public int BillId { get; set; }
       public string Fullname { get; set; }
       public string Email { get; set; }
        public Billing() { }

        public Billing(int customerBillId, string customerFullname, string customerEmail)
        {
            this.BillId = customerBillId;
            this.Fullname = customerFullname;
            this.Email = customerEmail;
          
        }

    }
}
