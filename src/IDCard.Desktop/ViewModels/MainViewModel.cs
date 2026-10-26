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
        private readonly PreferencesView _preferencesView = new PreferencesView();

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

        public MainViewModel()
        {
            _credentialsView.DataContext = new CredentialsViewModel();
            _reportsView.DataContext = new ReportsViewModel();
            _preferencesView.DataContext = new PreferencesViewModel();

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
                CurrentView = _preferencesView;
                CurrentPage = "Preferences";
                _preferencesView.SelectPreferencesTab();
            });

            NavigateChangePasswordCommand = new RelayCommand(_ => 
            {
                CurrentView = _preferencesView;
                CurrentPage = "Preferences";
                _preferencesView.SelectChangePasswordTab();
            });

            NavigateSettingsCommand = new RelayCommand(_ => 
            {
                CurrentView = _preferencesView;
                CurrentPage = "Preferences";
                _preferencesView.SelectPreferencesTab();
            });

            NavigateToolsCommand = new RelayCommand(_ => 
            {
                CurrentView = _preferencesView;
                CurrentPage = "Tools";
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
