using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IDCard.Desktop.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _currentView;

        public ICommand NavigateCredentialsCommand { get; }
        public ICommand NavigateReportsCommand { get; }

        public MainViewModel()
        {
            // အပလီကေးရှင်း စတင်ပွင့်လာချိန်တွင် Credentials View ကို ပထမဆုံးပြသရန်
            CurrentView = new CredentialsViewModel();

            // ခလုတ်များနှိပ်သည့်အခါ View ပြောင်းလဲရန် Command များကို ချိတ်ဆက်ခြင်း
            NavigateCredentialsCommand = new RelayCommand(() => CurrentView = new CredentialsViewModel());
            NavigateReportsCommand = new RelayCommand(() => CurrentView = new ReportsViewModel());
        }
    }
}
