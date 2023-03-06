using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    public class FixesViewModel : BaseViewModel
    {        
        private ObservableCollection<Vehicle> vehicles;
        private ObservableCollection<NewFixes> fixesinfo;
        private Vehicle selectedVehicle;
        private void GetFixes()
        {
            FixesInfo = DB_Connection.DisplayFixes(SelectedVehicle.id);
        }
        public ObservableCollection<Vehicle> Vehicles
        {
            get
            {
                this.vehicles = new ObservableCollection<Vehicle>();
                vehicles = DB_Connection.GetVehicles();
                return vehicles;
            }
        }
        public ObservableCollection<NewFixes> FixesInfo
        {
            get
            {
                return fixesinfo;
            }
            set
            {
                fixesinfo = value;
                OnPropertyChanged(nameof(FixesInfo));
            }
        }
        public Vehicle SelectedVehicle
        {
            get
            {
                return selectedVehicle;
            }
            set
            {
                selectedVehicle = value;
                GetFixes();
                this.OnPropertyChanged(nameof(SelectedVehicle));
            }
        }
    }
}