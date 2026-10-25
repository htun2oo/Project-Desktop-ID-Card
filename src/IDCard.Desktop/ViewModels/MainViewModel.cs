using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set { _currentView = value; OnPropertyChanged(); }
        }

        private string _currentPage = "Credentials";
        public string CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(); }
        }

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // Default Start View
            CurrentView = new CredentialsViewModel();
            CurrentPage = "Credentials";

            NavigateCredentialsCommand = new RelayCommand(_ => 
            {
                CurrentView = new CredentialsViewModel();
                CurrentPage = "Credentials";
            });

            NavigateReportsCommand = new RelayCommand(_ => 
            {
                CurrentView = new ReportsViewModel();
                CurrentPage = "Reports";
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
