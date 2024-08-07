using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using Haulage.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Haulage.BaseClasses.TripHandler;

namespace Haulage.viewModels
{
    public class ItemViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public ItemViewModel() 
        {
            Items = new ObservableCollection<Item>();
            var itemObjects = ItemModel.Items;
            foreach (var itemObject in itemObjects) 
            {
                Items.Add(itemObject);
            }
        }
    }
}
