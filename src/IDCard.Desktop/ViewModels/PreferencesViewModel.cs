using System.Windows;
using System.Windows.Input;

namespace IDCard.Desktop.ViewModels
{
    public class PreferencesViewModel : ViewModelBase
    {
        private string _currentPassword = string.Empty;
        public string CurrentPassword
        {
            get => _currentPassword;
            set { _currentPassword = value; OnPropertyChanged(); }
        }

        private string _newPassword = string.Empty;
        public string NewPassword
        {
            get => _newPassword;
            set { _newPassword = value; OnPropertyChanged(); }
        }

        private string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(); }
        }

        // Settings Properties
        private bool _displayLicenseTooltip;
        public bool DisplayLicenseTooltip
        {
            get => _displayLicenseTooltip;
            set { _displayLicenseTooltip = value; OnPropertyChanged(); }
        }

        private bool _alwaysShowQuickStart = true;
        public bool AlwaysShowQuickStart
        {
            get => _alwaysShowQuickStart;
            set { _alwaysShowQuickStart = value; OnPropertyChanged(); }
        }

        private int _maxRecordsPerReport = 1000;
        public int MaxRecordsPerReport
        {
            get => _maxRecordsPerReport;
            set { _maxRecordsPerReport = value; OnPropertyChanged(); }
        }

        public ICommand SavePreferencesCommand { get; }
        public ICommand UpdatePasswordCommand { get; }

        public PreferencesViewModel()
        {
            SavePreferencesCommand = new RelayCommand(ExecuteSavePreferences);
            UpdatePasswordCommand = new RelayCommand(ExecuteUpdatePassword);
        }

        private void ExecuteSavePreferences(object? parameter)
        {
            // Preferences setting များကို သိမ်းဆည်းသည့် လိုဂျစ်
            MessageBox.Show("Preferences saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExecuteUpdatePassword(object? parameter)
        {
            // Password Validation
            if (string.IsNullOrWhiteSpace(CurrentPassword) || string.IsNullOrWhiteSpace(NewPassword))
            {
                MessageBox.Show("Please fill in all password fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewPassword != ConfirmPassword)
            {
                MessageBox.Show("New passwords do not match!", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Password အောင်မြင်စွာ ပြောင်းလဲသည့် လိုဂျစ်
            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            
            // Clear fields after success
            CurrentPassword = string.Empty;
            NewPassword = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
