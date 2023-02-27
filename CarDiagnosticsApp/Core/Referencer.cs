using CarDiagnosticsApp.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDiagnosticsApp.Core
{
    public class Referencer
    {
        private BaseViewModel _currentView;
        public event Action OnCurrentViewChanged;
        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnCurrentViewChanged?.Invoke();
            }
        }
    }
}
