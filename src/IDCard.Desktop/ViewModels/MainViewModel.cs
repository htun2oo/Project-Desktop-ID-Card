using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Views;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _currentPage = "Home";
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly CredentialsView _credentialsView = new CredentialsView();
        private readonly ReportsView _reportsView = new ReportsView();
        private readonly SettingsView _settingsView = new SettingsView();
        private readonly ToolsView _toolsView = new ToolsView();

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateWorkflowsCommand { get; }
        public ICommand NavigateDesignReportsCommand { get; }
        public ICommand NavigateSmartCardWorkflowsCommand { get; }
        public ICommand NavigateFieldConnectionsCommand { get; }
        public ICommand NavigateReportsCommand { get; }
        public ICommand NavigatePreferencesCommand { get; }
        public ICommand NavigateChangePasswordCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateToolsCommand { get; }
        public ICommand NavigateUserManagementCommand { get; }
        public ICommand NavigateSystemDashboardCommand { get; }

        public MainViewModel()
        {
            _credentialsView.DataContext = new CredentialsViewModel();
            _reportsView.DataContext = new ReportsViewModel();

            CurrentView = _credentialsView;
            CurrentPage = "Home";

            NavigateHomeCommand = new RelayCommand(_ => 
            {
                CurrentView = _credentialsView;
                CurrentPage = "Home";
            });

            NavigateCredentialsCommand = new RelayCommand(_ => 
            {
                CurrentView = _credentialsView;
                CurrentPage = "CredentialDesigns";
            });

            NavigateWorkflowsCommand = new RelayCommand(_ => 
            {
                CurrentView = _credentialsView;
                CurrentPage = "Workflows";
            });

            NavigateDesignReportsCommand = new RelayCommand(_ => 
            {
                CurrentView = _reportsView;
                CurrentPage = "DesignReports";
            });

            NavigateSmartCardWorkflowsCommand = new RelayCommand(_ => 
            {
                CurrentView = _credentialsView;
                CurrentPage = "SmartCardWorkflows";
            });

            NavigateFieldConnectionsCommand = new RelayCommand(_ => 
            {
                CurrentView = _credentialsView;
                CurrentPage = "FieldConnections";
            });

            NavigateReportsCommand = new RelayCommand(_ => 
            {
                CurrentView = _reportsView;
                CurrentPage = "Reports";
            });

            NavigatePreferencesCommand = new RelayCommand(_ => 
            {
                CurrentView = _settingsView;
                CurrentPage = "Preferences";
                _settingsView.SelectPreferencesTab();
            });

            NavigateChangePasswordCommand = new RelayCommand(_ => 
            {
                CurrentView = _settingsView;
                CurrentPage = "Preferences";
                _settingsView.SelectChangePasswordTab();
            });

            NavigateSettingsCommand = new RelayCommand(_ => 
            {
                CurrentView = _settingsView;
                CurrentPage = "Preferences";
                _settingsView.SelectPreferencesTab();
            });

            NavigateToolsCommand = new RelayCommand(_ => 
            {
                CurrentView = _toolsView;
                CurrentPage = "Tools";
            });

            NavigateUserManagementCommand = new RelayCommand(_ => 
            {
                CurrentView = _settingsView;
                CurrentPage = "UserManagement";
            });

            NavigateSystemDashboardCommand = new RelayCommand(_ => 
            {
                CurrentView = _settingsView;
                CurrentPage = "SystemDashboard";
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
