using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public  class Administrator : Person
    {
        public Administrator() { }

        public void manageEmployees()
        {

        }

        public void manageVehicles()
        {

        }

        public void manageCustomers()
        {

        }

        public void manageBills()
        {

        }

        public void manageManifests()
        {

        }

        public void AddManifestItem(TripManifest manifest, ManifestItem item)
        {
            manifest.Items.Add(item);
        }

        public void RemoveManifestItem(TripManifest manifest, ManifestItem item)
        {
            manifest.Items.Remove(item);
        }

        public void UpdateManifestItem(TripManifest manifest, ManifestItem oldItem, ManifestItem newItem)
        {
            int index = manifest.Items.IndexOf(oldItem);
            if (index != -1)
            {
                manifest.Items[index] = newItem;
            }
        }

        public void planRoutes()
        {

        }

        public void resourceTrips()
        {

        }

        public void trackProgress()
        {

        }
    }

    public class TripManifest
    {
        public int ManifestId { get; set; }
        public int TripId { get; set; }
        public List<ManifestItem> Items { get; set; } = new List<ManifestItem>();
    }

    public class ManifestItem
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // Fragile, Dangerous, Other
    }

}
