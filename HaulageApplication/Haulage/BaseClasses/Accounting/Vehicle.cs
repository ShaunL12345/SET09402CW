using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    //Class to hold vehicle functionality
    public class Vehicle
    {
        //variables to contain vehicle attributes
        public Guid tripID;
        public string licensePlate;
        public int capacity;
        public Guid driverID;


        public enum status
        {

        }


        //Method to assign trip to a driver
        public void assignTrip()
        {
            
        }

    }
}
