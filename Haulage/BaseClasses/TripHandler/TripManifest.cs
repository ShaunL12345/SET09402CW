using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public class TripManifest
    {
        public Guid manifestId;
        public Guid tripId;
        public int pickUpRequest;

        public TripManifest() { }

        public void inspectItem()
        {

        }
    }
}
