using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.ViewModels
{
    public class CredentialsViewModel : INotifyPropertyChanged
    {
        private object? _currentViewContent;

        // Card Design များ သိမ်းဆည်းမည့် စာရင်း
        public ObservableCollection<CardDesignModel> CardDesigns { get; set; } = new ObservableCollection<CardDesignModel>();

        public object? CurrentViewContent
        {
            get => _currentViewContent;
            set { _currentViewContent = value; OnPropertyChanged(); }
        }

        public ICommand SwitchToGridViewCommand { get; }
        public ICommand SwitchToListViewCommand { get; }

        public CredentialsViewModel()
        {
            // Test Data များကို ယာယီထည့်သွင်းခြင်း
            CardDesigns.Add(new CardDesignModel { DesignName = "Staff ID Card", OwnerUsername = "admin" });
            CardDesigns.Add(new CardDesignModel { DesignName = "Visitor Badge", OwnerUsername = "user1" });

            // Command များ ချိတ်ဆက်ခြင်း
            SwitchToGridViewCommand = new RelayCommand(o => SetViewMode());
            SwitchToListViewCommand = new RelayCommand(o => SetViewMode());

            // Default အနေဖြင့် စတင်ပြသရန်
            CurrentViewContent = CardDesigns;
        }

        private void SetViewMode()
        {
            // View Mode ပြောင်းလဲသည့်အခါ Data ကို ချိတ်ဆက်ပေးခြင်း
            CurrentViewContent = CardDesigns;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
