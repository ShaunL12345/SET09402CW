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

// = MANAGE ACCOUNT = START ========================================================================================================= //
        public void ManageAccount(Account account, string billingDetails, string contactDetails)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            if (billingDetails == null) throw new ArgumentNullException(nameof(billingDetails));
            if (contactDetails == null) throw new ArgumentNullException(nameof(contactDetails));

            account.BillingDetails = billingDetails;
            account.ContactDetails = contactDetails;
        }

        public void RequestPickupOrDelivery() { }
        public void ConfirmPickupOrDelivery() { }
        public void TrackItem() { }
        public void ManageBilling() { }

// = MANAGE ACCOUNT = END =========================================================================================================== //

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

    }

// = ACCOUNT = START ================================================================================================================ //
    public class Account
    {
        public Guid AccountId { get; set; }
        public string BillingDetails { get; set; }
        public string ContactDetails { get; set; }

        public Account(Guid accountId, string billingDetails, string contactDetails)
        {
            AccountId = accountId;
            BillingDetails = billingDetails ?? throw new ArgumentNullException(nameof(billingDetails));
            ContactDetails = contactDetails ?? throw new ArgumentNullException(nameof(contactDetails));
        }
    }

// = ACCOUNT = END ================================================================================================================== //

}
