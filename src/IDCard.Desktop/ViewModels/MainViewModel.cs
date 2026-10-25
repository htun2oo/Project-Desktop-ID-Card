using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.ViewModels; // RelayCommand တည်ရှိရာ namespace

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // အပလီကေးရှင်း စတင်ပွင့်လာချိန်တွင် Credentials View ကို ပြသရန်
            CurrentView = new CredentialsViewModel();

            // သင့်ပရောဂျက်ပါ RelayCommand ကို အသုံးပြု၍ ချိတ်ဆက်ခြင်း
            NavigateCredentialsCommand = new RelayCommand(_ => CurrentView = new CredentialsViewModel());
            NavigateReportsCommand = new RelayCommand(_ => CurrentView = new ReportsViewModel());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
