using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object? _currentView; // object? သို့ ပြောင်းလဲခြင်း

        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // Default View အဖြစ် CredentialsViewModel ကို စတင်သတ်မှတ်ခြင်း
            CurrentView = new CredentialsViewModel();

            NavigateCredentialsCommand = new RelayCommand(_ => CurrentView = new CredentialsViewModel());
            NavigateReportsCommand = new RelayCommand(_ => CurrentView = new ReportsViewModel());
        }
    }
}
