using Limestock.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Limestock.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private readonly MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Dashboard")
                    viewModel.ViewModel = new DashboardViewModel();
            else if(parameter.ToString() == "Transaksi")
                    viewModel.ViewModel = new TransaksiViewModel();
            
        }
    }
}
