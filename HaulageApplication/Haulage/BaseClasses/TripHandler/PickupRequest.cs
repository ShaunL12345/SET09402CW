using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain PickUpRequest functionality
    public  class PickupRequest
    {
        //Variables to contain pickup request details to assist drivers
        public Guid requestId;
        public Guid customerId;
        public string pickupLocation;
        public string deliveryLocation;
        public Guid itemId;

        //Enum to contain status of item in transit
        public enum requestStatus
        {
            pickUpRequested,
            EnRouteToPickup,
            PickedUp,
        }
        public PickupRequest() { }

        //Method to inspect item
        public void inspectitem()
        {

        }
    }
}
