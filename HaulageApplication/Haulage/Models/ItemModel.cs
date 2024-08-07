using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using Haulage.BaseClasses.TripHandler;

namespace Haulage.Models
{
    public static class ItemModel
    {
        
        public static List<Item> Items = ItemExecutionService.GetItems();

    }
}
