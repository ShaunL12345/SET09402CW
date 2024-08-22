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
       public string Item {  get; set; }
       public string ItemDesc { get; set; }
       public double Cost { get; set; }
       public string Paid { get; set; }
       public int CustomerId { get; set; }
       public string CardNumber { get; set; }
       public string ExpiryDate { get; set; }
       public int SecurityCode { get; set; }
       public string NameOnCard { get; set; }
        public Billing() { }

        public Billing(int customerBillId, string customerFullname, string customerEmail, string customerItem, string customerItemDesc, double customerItemCost)
        {
            this.BillId = customerBillId;
            this.Fullname = customerFullname;
            this.Email = customerEmail;
            this.Item = customerItem;
            this.ItemDesc = customerItemDesc;
            this.Cost = customerItemCost;
          
        }

        public Billing(int customerId, string customerCardNumber, string customerExpiryDate, int customerSecurityCode, string customerNameOnCard)
        {
            this.CustomerId = customerId;
            this.CardNumber = customerCardNumber;
            this.ExpiryDate = customerExpiryDate;
            this.SecurityCode = customerSecurityCode;
            this.NameOnCard = customerNameOnCard;

        }
    }
}
