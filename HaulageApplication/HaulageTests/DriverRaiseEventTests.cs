using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xunit;
using SQLite;
using Haulage.DatabaseExecutionServices;
using Haulage.Models;
using Haulage.BaseClasses.Accounting;
using Haulage.viewModel;
using Haulage.AdminPages;
using Haulage.BaseClasses.TripHandler;

namespace HaulageTests
{
    public class DriverRaiseEventTests
    {
        [Fact]
        public void SaveVehicleToDatabse()
        {
            DatabaseSetup.InitializeDatabase();

            var eventCountBefore = DriverExecutionService.GetEvents().Count;

            TripEvent evt = new TripEvent()
            {
                DriverId = 1,
                TripId = 1,
                EventType = 0,
                Description = "Sheep in road"
            };
            DriverExecutionService.RaiseEvent(evt);
            
            var eventCountAfter = DriverExecutionService.GetEvents().Count;
            Assert.True(eventCountAfter == eventCountBefore + 1, "trip event record was not saved");
        }
    }
}
