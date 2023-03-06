using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;
using System.Collections.ObjectModel;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    class MotorsViewModel : BaseViewModel
    {
        private bool hideLbox;
        private Vehicle selectedVehicle;

        private ObservableCollection<Vehicle> motorsOnly;
        public Referencer CurrentRefrence { get; set; }

        public Vehicle SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                this.selectedVehicle = value;
                OnPropertyChanged(nameof(SelectedVehicle));
            }
        }
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
