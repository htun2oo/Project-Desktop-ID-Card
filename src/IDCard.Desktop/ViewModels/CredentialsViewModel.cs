using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.ViewModels
{
    public class CredentialsViewModel : INotifyPropertyChanged
    {
        private object? _currentViewContent;
        private DataTemplate? _gridViewTemplate;
        private DataTemplate? _listViewTemplate;

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
            // Test Data အနေဖြင့် ယာယီ ထည့်သွင်းပြသခြင်း (နောက်ပိုင်းတွင် Service မှ လှမ်းခေါ်မည်)
            CardDesigns.Add(new CardDesignModel { DesignName = "Staff ID Card", OwnerUsername = "admin" });
            CardDesigns.Add(new CardDesignModel { DesignName = "Visitor Badge", OwnerUsername = "user1" });

            // Command များ ချိတ်ဆက်ခြင်း
            SwitchToGridViewCommand = new RelayCommand(o => SetViewMode(true));
            SwitchToListViewCommand = new RelayCommand(o => SetViewMode(false));

            // Default အနေဖြင့် Grid View ဖြင့် စတင်ပြသရန်
            SetViewMode(true);
        }

        private void SetViewMode(bool isGrid)
        {
            // View Mode အလိုက် ပြောင်းလဲရန် လိုဂျစ်
            // (CredentialsView.xaml ထဲရှိ Template များနှင့် ချိတ်ဆက်ပေးခြင်း)
            CurrentViewContent = CardDesigns; 
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
