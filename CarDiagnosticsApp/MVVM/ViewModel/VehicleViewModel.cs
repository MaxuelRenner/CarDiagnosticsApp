using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    public class VehicleViewModel : BaseViewModel
    {
        private Vehicle selectedVehicle;

        private string brand;
        private string model;
        private string fuel;
        private string mileage;
        private string generation;
        private string plate;
        private string lastWindowName;
        public Referencer CurrentRefrence { get; set; }

        public string Brand
        {
            get { return brand; }
            set { 
                brand = value;
                OnPropertyChanged(nameof(Brand));
            }
        }
        public string Model
        {
            get { return model; }
            set { 
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }
        public string Fuel
        {
            get { return fuel; }
            set { 
                fuel = value;
                OnPropertyChanged(nameof(Fuel));
            }
        }
        public string Mileage
        {
            get { return mileage; }
            set { 
                mileage = value;
                OnPropertyChanged(nameof(Mileage));
            }
        }
        public string Generation
        {
            get { return generation; }
            set { 
                generation = value;
                OnPropertyChanged(nameof(Generation));

            }
        }
        public string Plate
        {
            get { return plate; }
            set
            {
                plate = value;
                OnPropertyChanged(nameof(Plate));
            }
        }
        public Vehicle SelectedVehicle
        {
            get { return selectedVehicle; }
            set
            {
                this.selectedVehicle = value;
                OnPropertyChanged(nameof(SelectedVehicle));
            }
        }
        public RelayCommand DeleteVehicleCommand => new RelayCommand(DeleteVehicle);
        public RelayCommand UpdateVehicleInfoCommand => new RelayCommand(UpdateInfo);
        private void UpdateInfo(object obj)
        {
            DB_Connection.Update(new Vehicle(this.selectedVehicle.id ,this.selectedVehicle.typeid, brand, model, generation, fuel, mileage, plate));
            ToBack();
        }
        private void DeleteVehicle(object obj)
        {
            DB_Connection.DeleteVehicle(SelectedVehicle.brand);
            ToBack();
        }
        private void ToBack()
        {
            switch (lastWindowName)
            {
                case "CarsViewModel":
                    CurrentRefrence.CurrentView = new CarsViewModel(CurrentRefrence);
                    break;

                case "MotorsViewModel":
                    CurrentRefrence.CurrentView = new MotorsViewModel(CurrentRefrence);
                    break;

                case "BusesViewModel":
                    CurrentRefrence.CurrentView = new BusesViewModel(CurrentRefrence);
                    break;
            }
        }
        public VehicleViewModel(Vehicle selectedVehicle, string LastWindowName, Referencer referencer)
        {
            this.CurrentRefrence = referencer;
            lastWindowName = LastWindowName;
            SelectedVehicle = selectedVehicle;
            this.brand = selectedVehicle.brand;
            this.model = selectedVehicle.model;
            this.generation = selectedVehicle.generation;
            this.fuel = selectedVehicle.fuel;
            this.mileage = selectedVehicle.mileage;
            this.plate = selectedVehicle.plate;
        }
    }
}