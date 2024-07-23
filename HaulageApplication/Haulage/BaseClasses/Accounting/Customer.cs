using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public class Customer : Person
    {
        public Customer() { }

        public void ManageAccount(Account account, string billingDetails, string contactDetails)
        {
            account.BillingDetails = billingDetails;
            account.ContactDetails = contactDetails;
        }

        public void requestPickupOrDelivery()
        {

        }

        public void confirmPickupOrDelivery()
        {

        }

        public void trackItem()
        {

        }

        public void manageBilling()
        {

        }

        public class Account
        {
            public Guid AccountID { get; set; }
            public Guid PersonID { get; set; }
            public string BillingDetails { get; set; } = string.Empty;
            public string ContactDetails { get; set; } = string.Empty;

            public Account() { }

            public Account(Guid personID, string billingDetails, string contactDetails)
            {
                AccountID = Guid.NewGuid();
                PersonID = personID;
                BillingDetails = billingDetails;
                ContactDetails = contactDetails;
            }
        }
    }
}
