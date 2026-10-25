using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.ViewModels;

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
                _currentView = value;
                OnPropertyChanged();
            }
        }

        // Active ဖြစ်နေသော Page ကို String ဖြင့် ခြေရာခံရန် (ဥပမာ: "Credentials", "Reports")
        private string _currentPage = "Credentials";
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // Default အနေဖြင့် Credentials ကို စတင်ပြသမည်
            CurrentView = new CredentialsViewModel();
            CurrentPage = "Credentials";

            // Home သို့မဟုတ် Credentials ကို နှိပ်သည့်အခါ
            NavigateCredentialsCommand = new RelayCommand(_ => 
            {
                CurrentView = new CredentialsViewModel();
                CurrentPage = "Credentials";
            });

            // Printer Queues သို့မဟုတ် Reports ကို နှိပ်သည့်အခါ
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
