using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain trip functionality
    public class Trip
    {
        //Variables to contain trip details
        public Guid tripId;
        public string startLocation;
        public string endLocation;

        //enum to hold status of a trip
        public enum tripStatus
        {
            atPickUpLocation,
            atDropOffLocation,
            Driving,
            paused,
        }
        public Trip() { }

        //Method to allow administrators / drivers to manage trips
        public void manageTrip()
        {

        }

        //Mthod to allow administrators / drivers update trip status
        public void updateTripStatus() 
        { 

        }
    }
}
