using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain Trip manifest functionality of the application
    public class TripManifest
    {
        //Variables to contain trip manifest attributes
        public Guid manifestId;
        public Guid tripId;
        public int pickUpRequest;

        public TripManifest() { }

        //Method to allow users to inspect an item
        public void inspectItem()
        {

        }
    }
}
