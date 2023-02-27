using CarDiagnosticsApp.Core;
using CarDiagnosticsApp.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarDiagnosticsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Referencer referencer = new Referencer();
            referencer.CurrentView = new HomeViewModel(referencer);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(referencer)

            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
