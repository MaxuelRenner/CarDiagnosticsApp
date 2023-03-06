using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.Model;
using System;
using System.Windows.Markup;

namespace CarDiagnosticsApp.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FixSectionViewCommand { get; set; }
        public RelayCommand FixesViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }
        public DiscoveryViewModel DiscoveryVm { get; set; }
        public FixSectionViewModel FixSectionVm { get; set; }
        public FixesViewModel FixesVm { get; set; }
        public Referencer CurrentRefrence { get; set; }

        public RelayCommand ToDescoveryCommand => new RelayCommand(SwitchScenes);

        private void SwitchScenes(object obj)
        {
            Referencer Secong = new Referencer();
            DiscoveryVm = new DiscoveryViewModel(Secong);
            CurrentRefrence.CurrentView = DiscoveryVm;
        }

        public BaseViewModel CurrentView => CurrentRefrence.CurrentView;
        public MainViewModel(Referencer CurrentRefrence)
        {
            this.CurrentRefrence = CurrentRefrence;
            this.CurrentRefrence.OnCurrentViewChanged += OnCurrentViewChanged;
            this.CurrentRefrence.CurrentView = this.CurrentView;
            HomeVm = new HomeViewModel(CurrentRefrence);
            FixSectionVm = new FixSectionViewModel();
            FixesVm = new FixesViewModel();

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentRefrence.CurrentView = HomeVm;
            });
            
            FixSectionViewCommand = new RelayCommand(o =>
            {
                CurrentRefrence.CurrentView = FixSectionVm;
            });

            FixesViewCommand = new RelayCommand(o =>
            {
                CurrentRefrence.CurrentView = FixesVm;
            });
        }
        public void OnCurrentViewChanged()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
