using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private string brand;
        private string model;
        private string generation;
        private string fuel;
        private string mileage;
        private string plate;

        private ObservableCollection<Type> types;
        private RelayCommand addVehicleCommand;
        private ICommand clearCommand;
        private Type selectedType;
        private Referencer CurrentRefrence;

        public HomeViewModel(Referencer referencer)
        {
            this.CurrentRefrence = referencer;           
        }

        public string Brand
        {
            get 
            {
                return brand; 
            }
            set 
            { 
                this.brand = value; 
                this.OnPropertyChanged(nameof(this.Brand));
            }
        }
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                this.model = value;
                this.OnPropertyChanged(nameof(this.Model));
            }
        }
        public string Generation
        {
            get
            {
                return generation;
            }
            set
            {
                this.generation = value;
                this.OnPropertyChanged(nameof(this.Generation));
            }
        }
        public string Fuel
        {
            get
            {
                return fuel;
            }
            set
            {
                this.fuel = value;
                this.OnPropertyChanged(nameof(this.Fuel));
            }
        }
        public string Mileage
        {
            get
            {
                return mileage;
            }
            set
            {
                this.mileage = value;
                this.OnPropertyChanged(nameof(this.Mileage));
            }
        }
        public string Plate
        {
            get
            {
                return plate;
            }
            set
            {
                this.plate = value;
                this.OnPropertyChanged(nameof(this.Plate));
            }
        }
        public ObservableCollection<Type> Types
        {
            get
            {
                this.types = new ObservableCollection<Type>();
                types = DB_Connection.GetTypes();
                SelectedType = types.FirstOrDefault();
                return types;
            }
        }
        public Type SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {

                selectedType = value;
                this.OnPropertyChanged(nameof(SelectedType));
            }
        }

        public RelayCommand AddVehicleCommand
        {
            get
            {

                this.addVehicleCommand = new RelayCommand(Add);
                return this.addVehicleCommand; 
            }
        }

        public ICommand ClearCommand
        {
            get
            {
                if (this.clearCommand == null)
                {
                    this.clearCommand = new RelayCommand(Cleaner);
                }
                return this.clearCommand;
            }
        }

        private void Cleaner(object obj)
        {
            this.Brand = null;
            this.Model = null;
            this.Generation = null;
            this.Fuel = null;
            this.Mileage = null;
            this.Plate = null;
        }

        private void Add(object obj)
        {
            
            DB_Connection.Insert(new Vehicle(this.selectedType.ID,this.brand,this.model,this.generation,this.fuel,this.mileage,this.plate));
            this.Brand = null;
            this.Model = null;
            this.Generation = null;
            this.Fuel = null;
            this.Mileage = null;
            this.Plate = null;
        }
    }
}
