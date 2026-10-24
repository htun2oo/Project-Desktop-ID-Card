using System.Linq;
using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;
using IDCard.Desktop.Services;

namespace IDCard.Desktop.ViewModels
{
    public class PreferencesViewModel : ViewModelBase
    {
        private readonly SettingsService _settingsService;
        private AppSettingsModel _currentSettings;

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

        // Settings Properties bound to UI
        public bool DisplayLicenseTooltip
        {
            get => _currentSettings.DisplayLicenseTooltip;
            set { _currentSettings.DisplayLicenseTooltip = value; OnPropertyChanged(); }
        }

        public bool AlwaysShowQuickStart
        {
            get => _currentSettings.AlwaysShowQuickStart;
            set { _currentSettings.AlwaysShowQuickStart = value; OnPropertyChanged(); }
        }

        public int MaxRecordsPerReport
        {
            get => _currentSettings.MaxRecordsPerReport;
            set { _currentSettings.MaxRecordsPerReport = value; OnPropertyChanged(); }
        }

        public ICommand SavePreferencesCommand { get; }
        public ICommand UpdatePasswordCommand { get; }

        public PreferencesViewModel()
        {
            _settingsService = new SettingsService();
            _currentSettings = _settingsService.LoadSettings();

            SavePreferencesCommand = new RelayCommand(ExecuteSavePreferences);
            UpdatePasswordCommand = new RelayCommand(ExecuteUpdatePassword);
        }

        private void ExecuteSavePreferences(object? parameter)
        {
            _settingsService.SaveSettings(_currentSettings);
            MessageBox.Show("Preferences saved successfully to local storage!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExecuteUpdatePassword(object? parameter)
        {
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

            if (UserSession.CurrentUser == null)
            {
                MessageBox.Show("No user session active!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                using var context = new AppDbContext();
                var user = context.Users.FirstOrDefault(u => u.Username == UserSession.CurrentUser.Username);

                if (user == null || user.Password != CurrentPassword)
                {
                    MessageBox.Show("Current password is incorrect!", "Authentication Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                user.Password = NewPassword;
                context.Users.Update(user);
                context.SaveChanges();

                // Update session as well
                UserSession.CurrentUser.Password = NewPassword;

                MessageBox.Show("Password updated successfully in database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                
                CurrentPassword = string.Empty;
                NewPassword = string.Empty;
                ConfirmPassword = string.Empty;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error updating password: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
