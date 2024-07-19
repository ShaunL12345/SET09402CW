using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;

namespace Haulage.DatabaseExecutionServices
{
    public static class VehicleModel
    {
        public static List<Vehicle> vehicles = VehicleExecutionService.GetVehicles();
    }
}
