using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Views;

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

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateWorkflowsCommand { get; }
        public ICommand NavigateReportsCommand { get; }
        public ICommand NavigateFieldConnectionsCommand { get; }

        public MainViewModel()
        {
            // Navigation Commands ချိတ်ဆက်ခြင်း
            NavigateCredentialsCommand = new RelayCommand(o => CurrentView = new CredentialsView());
            NavigateWorkflowsCommand = new RelayCommand(o => CurrentView = null); // လိုအပ်သော View ထည့်နိုင်သည်
            NavigateReportsCommand = new RelayCommand(o => CurrentView = null);     // လိုအပ်သော View ထည့်နိုင်သည်
            NavigateFieldConnectionsCommand = new RelayCommand(o => CurrentView = null); // လိုအပ်သော View ထည့်နိုင်သည်

            // Default အနေဖြင့် Credentials View ကို စတင်ပြသရန်
            CurrentView = new CredentialsView();
        }
    }
}
