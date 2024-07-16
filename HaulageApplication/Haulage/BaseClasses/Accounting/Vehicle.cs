using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{

    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int tripID { get; set; }
        public string LicensePlate { get; set; }
        public int Capacity { get; set; }
        public int DriverId { get; set; }
        public StatusType Status { get; set; }
        public enum StatusType
        {
            TestEnum1, TestEnum2, TestEnum3, TestEnum4,
        }
        public void assignTrip()
        {
            
        }

    }
}
