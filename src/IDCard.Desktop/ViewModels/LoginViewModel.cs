using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Services;
using IDCard.Desktop.Views;

namespace IDCard.Desktop.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        private string? _username;
        public string? Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string? _password;
        public string? Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _databaseService = new DatabaseService();
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isAuthenticated = _databaseService.ValidateUser(Username, Password);

            if (isAuthenticated)
            {
                // 1. Main Window ကို အရင်ဖွင့်ပါ
                var mainWindow = new MainWindow();
                mainWindow.Show();

                // 2. လက်ရှိ ပွင့်နေသော Login Window ကို ရှာပြီး အသေအချာ ပိတ်ပါ
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is LoginWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!\n(Default Admin: admin / admin123)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
