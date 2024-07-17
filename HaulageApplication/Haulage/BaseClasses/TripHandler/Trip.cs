using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain trip functionality of the application
    public class Trip
    {
        //Variables to contain trip attributes
        public Guid tripId;
        public string startLocation;
        public string endLocation;

        //Enum to contain status of a trip
        public enum tripStatus
        {
            atPickUpLocation,
            atDropOffLocation,
            Driving,
            paused,
        }

        public Trip() { }

        //Method to allow drivers and administrators to manage a trip
        public void manageTrip()
        {

        }

        //Method to allow drivers and administrators to update trip status
        public void updateTripStatus() 
        { 

        }
    }
}
