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
    public class FixSectionViewModel : BaseViewModel
    {
        private string data;
        private string mileage;
        private string price;
        private string machenicsname;
        private string service;
        private string desc;

        private ObservableCollection<Vehicle> vehicles;
        private ObservableCollection<FixTypes> typesF;
        private RelayCommand addFixCommand;
        private Vehicle selectedVehicle;
        private FixTypes selectedType;

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                this.data = value;
                this.OnPropertyChanged(nameof(this.Data));
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
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                this.price = value;
                this.OnPropertyChanged(nameof(this.Price));
            }
        }
        public string Machenicsname
        {
            get
            {
                return machenicsname;
            }
            set
            {
                this.machenicsname = value;
                this.OnPropertyChanged(nameof(this.Machenicsname));
            }
        }
        public string Service
        {
            get
            {
                return service;
            }
            set
            {
                this.service = value;
                this.OnPropertyChanged(nameof(this.Service));
            }
        }
        public string Desc
        {
            get
            {
                return desc;
            }
            set
            {
                this.desc = value;
                this.OnPropertyChanged(nameof(this.Desc));
            }
        }
        public ObservableCollection<Vehicle> Vehicles
        {
            get
            {
                this.vehicles = new ObservableCollection<Vehicle>();
                vehicles = DB_Connection.GetVehicles();
                SelectedVehicle = vehicles.FirstOrDefault();
                return vehicles;
            }
        }

        public ObservableCollection<FixTypes> FixTypes
        {
            get
            {
                this.typesF = new ObservableCollection<FixTypes>();
                typesF = DB_Connection.GetAllFixTypes();
                SelectedType = typesF.FirstOrDefault();
                return typesF;
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
                this.OnPropertyChanged(nameof(SelectedVehicle));
            }
        }

        public FixTypes SelectedType
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

        public RelayCommand AddFixCommand
        {
            get
            {

                this.addFixCommand = new RelayCommand(Add);
                return this.addFixCommand;
            }
        }

        private void Add(object obj)
        {
            DB_Connection.AddFix(new NewFixes(this.selectedType.ID, this.selectedVehicle.id, this.data, this.mileage, this.price, this.machenicsname, this.service, this.desc));
            this.Data = null;
            this.Mileage = null;
            this.Price = null;
            this.Machenicsname = null;
            this.Service = null;
            this.Desc = null;
        }
    }
}
