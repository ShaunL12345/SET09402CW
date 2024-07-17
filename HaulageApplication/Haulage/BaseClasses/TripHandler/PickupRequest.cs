using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain PickupRequest functionality of the application
    public  class PickupRequest
    {
        //Variables to contain pickup request attributes
        public Guid requestId;
        public Guid customerId;
        public string pickupLocation;
        public string deliveryLocation;
        public Guid itemId;

        //Enum to contain the request status of a pickup or delivery
        public enum requestStatus
        {
            pickUpRequested,
            EnRouteToPickup,
            PickedUp,
        }

        public PickupRequest() { }

        //Method to allow users to inspect items 
        public void inspectitem()
        {

        }
    }
}
