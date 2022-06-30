using PasswordManager.WPF.Common.Base;
using PasswordManager.WPF.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PasswordManager.WPF.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private Dictionary<string, IViewModel> _viewModel;
        public MainViewModel()
        {
            _viewModel = new Dictionary<string, IViewModel>
            {
                { "Accounts", new AccountsViewModel() },
                { "Import", new ImportViewModel() },
                { "Export", new ExportViewModel() }
            };


            InitCommand();
        }

        private IViewModel _currentView;
        public IViewModel CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigationCommand { get; set; }

        private void InitCommand()
        {
            NavigationCommand = new RelayCommand(o =>
            {
                var buttonName = o as string;

                if(string.IsNullOrEmpty(buttonName) || _viewModel.ContainsKey(buttonName) == false)
                {
                    CurrentView = _viewModel["Accounts"];
                    return;
                }

                var view = _viewModel[buttonName];
                CurrentView = view;
            });
        }


    }
}
