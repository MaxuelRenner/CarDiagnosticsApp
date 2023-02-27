using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    class BusesViewModel : BaseViewModel
    {
        private bool hideLbox;
        public Referencer CurrentRefrence { get; set; }

        private Vehicle selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                this.selectedVehicle = value;
                OnPropertyChanged(nameof(SelectedVehicle));
            }
        }

        private ObservableCollection<Vehicle> busesOnly;

        public BusesViewModel(Referencer referencer)
        {
            this.CurrentRefrence = referencer;
            this.BusesOnly = DB_Connection.GetBusesOnly();
        }

        public ObservableCollection<Vehicle> BusesOnly
        {
            get { return busesOnly; }
            set
            {
                busesOnly = value;
                OnPropertyChanged(nameof(BusesOnly));
            }
        }

        public RelayCommand OpenBusesViewCommand => new RelayCommand(OpenViewBuses);
        private void OpenViewBuses(object obj)
        {
            CurrentRefrence.CurrentView = new VehicleViewModel(selectedVehicle, "BusesViewModel", CurrentRefrence);
        }

        public bool HideLBox
        {
            get { return hideLbox; }
            set
            {
                hideLbox = value;
                OnPropertyChanged(nameof(hideLbox));
            }
        }

        public void FixInfo()
        {
            HideLBox = true;
        }
    }
}
