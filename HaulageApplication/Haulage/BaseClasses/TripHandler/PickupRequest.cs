using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public  class PickupRequest
    {
        public Guid requestId;
        public Guid customerId;
        public string pickupLocation;
        public string deliveryLocation;
        public Guid itemId;
        public enum requestStatus
        {
            pickUpRequested,
            EnRouteToPickup,
            PickedUp,
            droppedoff
        }
        public PickupRequest()
        {

        }

        public void inspectitem()
        {

        }
    }
}
