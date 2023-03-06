using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    class DiscoveryViewModel : BaseViewModel
    {
        public RelayCommand CarsViewCommand { get; set; }
        public RelayCommand MotorsViewCommand { get; set; }
        public RelayCommand BusesViewCommand { get; set; }
        public CarsViewModel CarsVm { get; set; }
        public MotorsViewModel MotorsVm { get; set; }
        public BusesViewModel BusesVm { get; set; }
        public Referencer CurrentRefrence { get; set; }
        public BaseViewModel CurrentView => CurrentRefrence.CurrentView;

        public DiscoveryViewModel(Referencer CurrentRefrence)
        {
            this.CurrentRefrence = CurrentRefrence;
            this.CurrentRefrence.OnCurrentViewChanged += OnCurrentViewChanged;

            CarsVm = new CarsViewModel(this.CurrentRefrence);
            MotorsVm = new MotorsViewModel(this.CurrentRefrence);
            BusesVm = new BusesViewModel(this.CurrentRefrence);

            CarsViewCommand = new RelayCommand(o =>
            {
                CurrentRefrence.CurrentView = CarsVm;
            });

            MotorsViewCommand = new RelayCommand(o =>
            {
                CurrentRefrence.CurrentView = MotorsVm;
            });

            BusesViewCommand = new RelayCommand(o =>
            {
                CurrentRefrence.CurrentView = BusesVm;
            });
        }
        public void OnCurrentViewChanged()
        {
            if(CarsVm != null) 
            {
                CarsVm = null;
            }
            CarsVm = new CarsViewModel(this.CurrentRefrence);
            if (MotorsVm != null)
            {
                MotorsVm = null;
            }
            MotorsVm = new MotorsViewModel(this.CurrentRefrence);
            if (BusesVm != null)
            {
                BusesVm = null;
            }
            BusesVm = new BusesViewModel(this.CurrentRefrence);
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}