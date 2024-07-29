using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haulage.BaseClasses.Accounting
{
    public  class Administrator : User
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
            // Plan routes logic here
        }

        public void resourceTrips()
        {
            // Resource trips logic here
        }

        public void trackProgress(List<Trip> trips)
        {
            foreach (var trip in trips)
            {
                Console.WriteLine($"Trip ID: {trip.TripId}");
                Console.WriteLine($"Current Location: {trip.CurrentLocation}");
                Console.WriteLine($"Status: {trip.Status}");
                Console.WriteLine($"Issues: {trip.Issues}");
            }
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

        public ManifestItem(int itemId, string description, string category)
        {
            ItemId = itemId;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Category = category ?? throw new ArgumentNullException(nameof(category));
        }
    }

    public class Trip
    {
        public int TripId { get; set; }
        public string CurrentLocation { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Issues { get; set; } = string.Empty;

        public Trip(int tripId, string currentLocation, string status, string issues)
        {
            TripId = tripId;
            CurrentLocation = currentLocation ?? throw new ArgumentNullException(nameof(currentLocation));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Issues = issues ?? throw new ArgumentNullException(nameof(issues));
        }
    }

}
