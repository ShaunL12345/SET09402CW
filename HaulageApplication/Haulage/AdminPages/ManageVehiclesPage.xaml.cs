using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using Haulage.viewModel;
using Microsoft.Maui.Controls;

using System.Collections.ObjectModel;

namespace Haulage;

public partial class ManageVehiclesPage : ContentPage
{
    
    public ManageVehiclesPage()
    {
        InitializeComponent();
        //VehiclesCollectionView.ItemsSource = VehicleViewModel().vehicle;
    }
    public static void createGrid() 
    {
        CollectionView collectionView = new CollectionView();
        collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Haulage.viewModel:Vehicles");

        collectionView.ItemTemplate = new DataTemplate(() =>
        {
            Grid grid = new Grid { Padding = 10 };
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Label VehicleIdLabel = new Label { FontAttributes = FontAttributes.Bold };
            VehicleIdLabel.SetBinding(Label.TextProperty, "VehicleId");
            
            Label tripIDLabel = new Label { FontAttributes = FontAttributes.Bold };
            tripIDLabel.SetBinding(Label.TextProperty, "tripID");
            
            Label CapacityLabel = new Label { FontAttributes = FontAttributes.Bold };
            CapacityLabel.SetBinding(Label.TextProperty, "Capacity");
           
            Label DriverIdLabel = new Label { FontAttributes = FontAttributes.Bold };
            DriverIdLabel.SetBinding(Label.TextProperty, "DriverId");

            Label StatusLabel = new Label { FontAttributes = FontAttributes.Bold };
            StatusLabel.SetBinding(Label.TextProperty, "Status");


            Label locationLabel = new Label { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
            locationLabel.SetBinding(Label.TextProperty, "LicensePlate");

            grid.Add(VehicleIdLabel,1, 0);
            grid.Add(tripIDLabel, 1, 1);
            grid.Add(CapacityLabel, 1, 2);
            grid.Add(DriverIdLabel, 1, 3);
            grid.Add(StatusLabel, 1, 4);
            grid.Add(locationLabel, 1, 5);


            return grid;
        });
    }
}