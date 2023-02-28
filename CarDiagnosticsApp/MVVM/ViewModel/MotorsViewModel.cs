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
    class MotorsViewModel : BaseViewModel
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

        private ObservableCollection<Vehicle> motorsOnly;

        public MotorsViewModel(Referencer referencer)
        {
            this.CurrentRefrence = referencer;
            this.MotorsOnly = DB_Connection.GetMotorsOnly();
        }

        public ObservableCollection<Vehicle> MotorsOnly
        {
            get { return motorsOnly; }
            set
            {
                motorsOnly = value;
                OnPropertyChanged(nameof(MotorsOnly));
            }
        }

        public RelayCommand OpenMotorsViewCommand => new RelayCommand(OpenViewMotors);
        private void OpenViewMotors(object obj)
        {
            if (selectedVehicle != null)
            {
                CurrentRefrence.CurrentView = new VehicleViewModel(selectedVehicle, "MotorsViewModel", CurrentRefrence);
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
