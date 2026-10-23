using System.Windows;
using System.Windows.Input;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigatePreferencesCommand { get; set; } = null!;
        public ICommand ExitCommand { get; }

        public MainViewModel()
        {
            // Default View သို့မဟုတ် Command များ ချိတ်ဆက်ခြင်း
            ExitCommand = new RelayCommand(ExecuteExit);
        }

        private void ExecuteExit(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
