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

        private string _homeSubTab = "Credentials";
        public string HomeSubTab
        {
            get => _homeSubTab;
            set
            {
                if (_homeSubTab != value)
                {
                    _homeSubTab = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly CredentialsView _credentialsView = new CredentialsView(); 
        private readonly CredentialDesignsView _credentialDesignsView = new CredentialDesignsView();
        private readonly WorkflowDesignsView _workflowDesignsView = new WorkflowDesignsView();
        private readonly ReportDesignsView _reportDesignsView = new ReportDesignsView();
        private readonly FieldConnectionDesignsView _fieldConnectionDesignsView = new FieldConnectionDesignsView();
        private readonly ReportsView _reportsView = new ReportsView();
        private readonly PrinterQueuesView _printerQueuesView = new PrinterQueuesView();
        private readonly SettingsView _settingsView = new SettingsView();
        private readonly ToolsView _toolsView = new ToolsView();
        private readonly UserManagementView _userManagementView = new UserManagementView();
        private readonly SystemDashboardView _systemDashboardView = new SystemDashboardView();

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateHomeCredentialsCommand { get; }
        public ICommand NavigateHomeReportsCommand { get; }
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
        public ICommand SignOutCommand { get; }

        public ICommand EnterWorkflowEditorCommand { get; }
        public ICommand ExitWorkflowEditorCommand { get; }

        public MainViewModel()
        {
            _credentialsView.DataContext = new CredentialsViewModel();
            _reportsView.DataContext = new ReportsViewModel();

            var workflowDesignsVm = new WorkflowDesignsViewModel(
                enterEditor: () => EnterWorkflowEditorCommand.Execute(null),
                exitEditor: () => ExitWorkflowEditorCommand.Execute(null)
            );
            _workflowDesignsView.DataContext = workflowDesignsVm;

            CurrentView = _credentialsView;
            CurrentPage = "Home";
            HomeSubTab = "Credentials";

            NavigateHomeCommand = new RelayCommand(_ =>  
            {
                CurrentView = _credentialsView;
                CurrentPage = "Home";
                HomeSubTab = "Credentials";
            });

            NavigateHomeCredentialsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _credentialsView;
                CurrentPage = "Home";
                HomeSubTab = "Credentials";
            });

            NavigateHomeReportsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _reportsView;
                CurrentPage = "Home";
                HomeSubTab = "Reports";
            });

            NavigateCredentialsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _credentialDesignsView;
                CurrentPage = "CredentialDesigns";
            });

            NavigateWorkflowsCommand = new RelayCommand(_ =>  
            {
                workflowDesignsVm.ResetToListView();
                CurrentView = _workflowDesignsView;
                CurrentPage = "Workflows";
            });

            NavigateDesignReportsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _reportDesignsView;
                CurrentPage = "DesignReports";
            });

            NavigateSmartCardWorkflowsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _credentialsView;
                CurrentPage = "SmartCardWorkflows";
            });

            NavigateFieldConnectionsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _fieldConnectionDesignsView;
                CurrentPage = "FieldConnections";
            });

            NavigateReportsCommand = new RelayCommand(_ =>  
            {
                CurrentView = _printerQueuesView;
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
                CurrentView = _userManagementView;
                CurrentPage = "UserManagement";
            });

            NavigateSystemDashboardCommand = new RelayCommand(_ =>  
            {
                CurrentView = _systemDashboardView;
                CurrentPage = "SystemDashboard";
            });

            EnterWorkflowEditorCommand = new RelayCommand(_ => 
            {
                CurrentPage = "WorkflowEditor";
            });

            ExitWorkflowEditorCommand = new RelayCommand(_ => 
            {
                CurrentPage = "Workflows";
            });

            SignOutCommand = new RelayCommand(_ =>  
            {
                if (System.Windows.Application.Current.MainWindow is Views.MainWindow mainWindow)
                {
                    mainWindow.Close();
                }
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
