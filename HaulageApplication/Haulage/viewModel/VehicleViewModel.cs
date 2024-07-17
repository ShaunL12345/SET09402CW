using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses.Accounting;
using Haulage.DatabaseExecutionServices;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Haulage.viewModel
{
    public class VehicleViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Vehicle> Vehicles { get; set; }
        public VehicleViewModel() 
        {
            Vehicles = new ObservableCollection<Vehicle>();
            var vehicleObjects = VehicleExecutionService.getVehicles();
            foreach (var vehicleObject in vehicleObjects) 
            {
                Vehicles.Add(vehicleObject);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
