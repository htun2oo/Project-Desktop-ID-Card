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
            // JSON File မှတဆင့် Username နှင့် Password စစ်ဆေးခြင်း
            var user = UserService.Authenticate(Username, Password);

            if (user != null)
            {
                // Active User Session သတ်မှတ်ခြင်း
                UserSession.CurrentUser = user;

                MessageBox.Show($"Login Successful! Welcome {user.Username} ({user.Role})", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                var mainWindow = new MainWindow();

                // အရေးကြီးသည် - MainWindow အသစ်ကို Application ၏ Main Window အဖြစ် ဦးစွာသတ်မှတ်ပါ
                Application.Current.MainWindow = mainWindow;

                mainWindow.Show();

                // ထို့နောက်မှ Login Window ကို ပိတ်ပါ
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
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
