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
    public class DriverViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Driver>? drivers { get; set; }
        public DriverViewModel()
        {
            drivers = new ObservableCollection<Driver>();
            var DriverObjects = DriverModel.drivers;
            foreach (var DriverObject in DriverObjects)
            {
                drivers.Add(DriverObject);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}