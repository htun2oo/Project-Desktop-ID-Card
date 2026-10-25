using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Views;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object? _currentView;
        public object? CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _currentPage = "CredentialDesigns";
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged();
                }
            }
        }

        // Cached Views များ (Instance တစ်ခုတည်းကိုသာ အသုံးပြုရန်)
        private readonly CredentialsView _credentialsView = new CredentialsView();
        private readonly ReportsView _reportsView = new ReportsView();

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // Default Start View နှင့် DataContext များ ချိတ်ဆက်ခြင်း
            _credentialsView.DataContext = new CredentialsViewModel();
            _reportsView.DataContext = new ReportsViewModel();

            CurrentView = _credentialsView;
            CurrentPage = "CredentialDesigns";

            NavigateCredentialsCommand = new RelayCommand(_ => 
            {
                CurrentView = _credentialsView;
                CurrentPage = "CredentialDesigns";
            });

            NavigateReportsCommand = new RelayCommand(_ => 
            {
                CurrentView = _reportsView;
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
