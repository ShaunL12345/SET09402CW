using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Haulage.BaseClasses.Accounting;

namespace HaulageTests
{
    public class AdministratorTests
    {
        [Fact]
        public void AddManifestItem_ShouldAddItemToManifest()
        {
            // Arrange
            var admin = new Administrator();
            var manifest = new TripManifest();
            var item = new ManifestItem(1, "Item 1", "Other");

            // Act
            admin.AddManifestItem(manifest, item);

            // Assert
            Assert.Contains(item, manifest.Items);
        }

        [Fact]
        public void RemoveManifestItem_ShouldRemoveItemFromManifest()
        {
            // Arrange
            var admin = new Administrator();
            var manifest = new TripManifest();
            var item = new ManifestItem(1, "Item 1", "Other");
            manifest.Items.Add(item);

            // Act
            admin.RemoveManifestItem(manifest, item);

            // Assert
            Assert.DoesNotContain(item, manifest.Items);
        }

        [Fact]
        public void UpdateManifestItem_ShouldUpdateItemInManifest()
        {
            // Arrange
            var admin = new Administrator();
            var manifest = new TripManifest();
            var oldItem = new ManifestItem(1, "Item 1", "Other");
            var newItem = new ManifestItem(1, "Updated Item 1", "Fragile");
            manifest.Items.Add(oldItem);

            // Act
            admin.UpdateManifestItem(manifest, oldItem, newItem);

            // Assert
            Assert.Contains(newItem, manifest.Items);
            Assert.DoesNotContain(oldItem, manifest.Items);
        }


        [Fact]
        public void TrackProgress_ShouldPrintTripStatuses()
        {
            // Arrange
            var admin = new Administrator();
            var trips = new List<Trip>
            {
                new Trip(1, "Location 1", "On Time", "None"),
                new Trip(2, "Location 2", "Delayed", "Traffic")
            };

            // Act
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                admin.trackProgress(trips);

                // Assert
                var output = sw.ToString();
                Assert.Contains("Trip ID: 1", output);
                Assert.Contains("Current Location: Location 1", output);
                Assert.Contains("Status: On Time", output);
                Assert.Contains("Issues: None", output);

                Assert.Contains("Trip ID: 2", output);
                Assert.Contains("Current Location: Location 2", output);
                Assert.Contains("Status: Delayed", output);
                Assert.Contains("Issues: Traffic", output);
            }
        }
    }
}
