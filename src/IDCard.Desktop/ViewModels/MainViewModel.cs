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
            // Default အနေဖြင့် Credentials View ကို စတင်ပြသမည်
            CurrentView = new CredentialsViewModel();

            NavigateCredentialsCommand = new RelayCommand(_ => CurrentView = new CredentialsViewModel());
            NavigateReportsCommand = _ => CurrentView = new ReportsViewModel();
        }
    }
}
