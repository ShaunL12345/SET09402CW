using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain trip manifest functionality 
    public class TripManifest
    {
        //varibles to contain attributes related to trip manifest
        public Guid manifestId;
        public Guid tripId;
        public int pickUpRequest;

        public TripManifest() { }

        //method to allow drivers / administrators to inspect trip manifest
        public void inspectItem()
        {

        }
    }
}
