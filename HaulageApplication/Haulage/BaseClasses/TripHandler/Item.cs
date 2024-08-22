﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.TripHandler
{
    
    public class Item
    {
        public enum ItemCategoryType
        {
            Fragile,
            Dangerous,
            None
        }
        //public enum RequestStatusType
        //{
        //    pickUpRequested,
        //    EnRouteToPickup,
        //    PickedUp,
        //}
        public Guid itemID;
        public string description;
        public ItemCategoryType itemCategory;
        public bool signedOff;
        public Item() { }
        public int ItemId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool SignedOff { get; set; }
        public ItemCategoryType ItemCategory { get; set; }
        public PickupRequest.requestStatus RequestStatus { get; set; }

        public void inspectItem(){

        }

    }
}
