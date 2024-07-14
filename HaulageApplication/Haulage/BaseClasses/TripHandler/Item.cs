using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to hold item attributes / functionality
    public class Item
    {
        //variables to contain item details
        public Guid itemID;
        public string description;
        public bool itemCategory;
        public bool signedOff;
        public Item() { }

        //class to allow customers to inspect item
        public void inspectItem(){

        }

    }
}
