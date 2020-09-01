using Limestock.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Limestock.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _ViewModel = new DashboardViewModel();

        public BaseViewModel ViewModel
        {
            get { return _ViewModel; }
            set {
                _ViewModel = value;
                OnPropertyChanged(nameof(ViewModel));
            }
        }
        public ICommand UpdateView { get; set; }

        public MainViewModel()
        {
            UpdateView = new UpdateViewCommand(this);
        }

    }
}
