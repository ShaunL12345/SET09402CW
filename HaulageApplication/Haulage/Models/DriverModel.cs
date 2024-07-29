using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;

namespace Haulage.DatabaseExecutionServices
{
    public static class DriverModel
    {

        public static List<Driver> Drivers = DriverExecutionService.GetDrivers();

    }
}