using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public class TripEvent
    {

        public enum Eventtype
        {
            Delay,
            Emergency
        }
        public int TripId { get; set; }
        public int DriverId { get; set; }
        public Eventtype EventType { get; set; }
        public string? Description {  get; set; }



    }
}
