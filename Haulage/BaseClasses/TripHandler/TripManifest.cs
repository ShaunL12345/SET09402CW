using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public class TripManifest
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public Guid tripId;
        public int pickUpRequest;

        public TripManifest() { }

        public void inspectItem()
        {

        }
    }
}
