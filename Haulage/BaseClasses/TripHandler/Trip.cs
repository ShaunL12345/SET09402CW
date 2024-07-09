using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public class Trip
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string startLocation;
        public string endLocation;
        public enum tripStatus
        {
            atPickUpLocation,
            atDropOffLocation,
            Driving,
            paused,
        }
        public Trip() { }

        public void manageTrip()
        {

        }

        public void updateTripStatus() 
        { 

        }
    }
}
