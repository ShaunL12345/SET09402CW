﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;

namespace Haulage.Models
{
    public static class VehicleModel
    {
        
        public static readonly List<Vehicle> vehicles = VehicleExecutionService.GetVehicles();

    }
}
