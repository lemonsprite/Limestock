using System;
using System.Collections.Generic;
using System.Text;

namespace Limestock.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _ViewModel = new DashboardViewModel();

        public BaseViewModel ViewModel
        {
            get { return _ViewModel; }
            set { _ViewModel = value; }
        }

    }
}
