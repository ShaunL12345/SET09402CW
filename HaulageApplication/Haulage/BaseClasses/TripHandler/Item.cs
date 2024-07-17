using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    //Class to contain the Item functionality of the application
    public class Item
    {
        //Variables to contain the attributes of items 
        public Guid itemID;
        public string description;
        public bool itemCategory;
        public bool signedOff;

        public Item() { }

        //Method to allow users to inspect items
        public void inspectItem(){

        }

    }
}
