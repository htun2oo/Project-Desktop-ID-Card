using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Services;
using IDCard.Desktop.Views;

namespace IDCard.Desktop.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username = string.Empty;
        private string _password = string.Empty;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin(object? parameter)
        {
            var user = UserService.Authenticate(Username, Password);

            if (user != null)
            {
                UserSession.CurrentUser = user;

                MessageBox.Show($"Login Successful! Welcome {user.Username} ({user.Role})", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                var mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;

                // Login Window ကို ချက်ချင်း ဖုံးကွယ်လိုက်ခြင်းဖြင့် တစ်ချက်မြင်ရခြင်းကို လုံးဝ တားဆီးနိုင်သည်
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is LoginWindow loginWin)
                    {
                        loginWin.Hide();
                        break;
                    }
                }

                mainWindow.Show();

                // ထို့နောက်မှ အပြီးပိတ်ရန်
                foreach (Window window in Application.Current.Windows)
                {
                    if (window is LoginWindow loginWinToClose)
                    {
                        loginWinToClose.Close();
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
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
