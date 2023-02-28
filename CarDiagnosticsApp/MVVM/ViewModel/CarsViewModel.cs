using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;
using CarDiagnosticsApp.MVVM.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    class CarsViewModel : BaseViewModel
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

        private ObservableCollection<Vehicle> carsOnly;

        public CarsViewModel(Referencer referencer)
        {
            this.CurrentRefrence = referencer;
            this.CarsOnly = DB_Connection.GetCarsOnly();
        }

        public ObservableCollection<Vehicle> CarsOnly
        {
            get { return carsOnly; }
            set
            {
                carsOnly = value;
                OnPropertyChanged(nameof(CarsOnly));
            }
        }

        public RelayCommand OpenCarViewCommand => new RelayCommand(OpenViewCar);
        private void OpenViewCar(object obj)
        {
            if (selectedVehicle != null)
            {
                CurrentRefrence.CurrentView = new VehicleViewModel(selectedVehicle, "CarsViewModel", CurrentRefrence);
            }
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