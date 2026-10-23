using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand SignOutCommand { get; }

        public MainViewModel()
        {
            // Sign Out Command ကို သတ်မှတ်ခြင်း
            SignOutCommand = new RelayCommand(ExecuteSignOut);
        }

        private void ExecuteSignOut(object? parameter)
        {
            // MainWindow ကိုသာ Login Window မပြဘဲ တိုက်ရိုက်ပိတ်ရန်
            foreach (Window window in Application.Current.Windows)
            {
                if (window is Views.MainWindow)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
