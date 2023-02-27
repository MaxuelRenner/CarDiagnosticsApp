using CarDiagnosticsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    public class FixesViewModel : BaseViewModel
    {
        private ObservableCollection<Vehicle> vehicles;

        private Vehicle selectedVehicle;


        public ObservableCollection<Vehicle> Vehicles
        {
            get
            {
                this.vehicles = new ObservableCollection<Vehicle>();
                vehicles = DB_Connection.GetVehicles();
                return vehicles;
            }
        }

        public Vehicle SelectedVehicle
        {
            get
            {
                return selectedVehicle = vehicles.FirstOrDefault();
            }
            set
            {

                selectedVehicle = value;
                this.OnPropertyChanged(nameof(SelectedVehicle));
            }
        }
    }
}
