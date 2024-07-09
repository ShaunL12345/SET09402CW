using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string description;
        public bool itemCategory;
        public bool signedOff;
        public Item() { }

        public void inspectItem(){

        }

    }
}
