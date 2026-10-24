using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // Default View အဖြစ် CredentialsViewModel ကို သတ်မှတ်ခြင်း
            CurrentView = new CredentialsViewModel();

            // RelayCommand ကို အသုံးပြု၍ Command များကို ချိတ်ဆက်ခြင်း
            NavigateCredentialsCommand = new RelayCommand(_ => CurrentView = new CredentialsViewModel());
            NavigateReportsCommand = new RelayCommand(_ => CurrentView = new ReportsViewModel());
        }
    }
}
