using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    //Class to contain Vehicle functionality of the application
    public class Vehicle
    {
        //Variables to contain the attributes of a vehicle
        public Guid tripID;
        public string licensePlate;
        public int capacity;
        public Guid driverID;

        
        public enum status
        {

        }

        //Method to allow administrators to assign a vehicle to a trip
        public void assignTrip()
        {
            
        }

    }
}
