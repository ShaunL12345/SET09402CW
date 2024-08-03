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
using Haulage.DriverPages;
using NuGet.Frameworks;

namespace HaulageTests
{
    [CollectionDefinition("DatabaseTests", DisableParallelization = true)]
    public class DriverRaiseEventTests
    {
        [Fact]
        public void DriverRaiseEventFromEntry()
        {
            DatabaseSetup.InitializeDatabase();
            Entry DriverIdEntry = new Entry();
            DriverIdEntry.Text = "111";
            Entry TripIdEntry = new Entry();
            TripIdEntry.Text = "11";
            Entry EventTypeEntry = new Entry();
            EventTypeEntry.Text = "1";
            Entry DescriptionEntry = new Entry();
            DescriptionEntry.Text = "1";
            var eventCountBefore = DriverExecutionService.GetEvents().Count;
            (string status, string message, string button) = DriverRaiseEventPage.raiseEvent(DriverIdEntry,
                                    TripIdEntry,
                                    EventTypeEntry,
                                    DescriptionEntry);

            var eventCountAfter = DriverExecutionService.GetEvents().Count;
            Assert.True(status == "Success");
            Assert.True(button == "OK");
            Assert.True(eventCountAfter == eventCountBefore + 1, "trip event record was not saved");
        }

        [Fact]
        public void DriverRaiseEvent()
        {
            DatabaseSetup.InitializeDatabase();

            var eventCountBefore = DriverExecutionService.GetEvents().Count;

            TripEvent raisedEvent = new TripEvent()
            {
                DriverId = 1,
                TripId = 1,
                EventType = 0,
                Description = "Sheep in road"
            };
            DriverExecutionService.RaiseEvent(raisedEvent);
            
            var eventCountAfter = DriverExecutionService.GetEvents().Count;
            Assert.True(eventCountAfter == eventCountBefore + 1, "trip event record was not saved");
        }
    }
}
