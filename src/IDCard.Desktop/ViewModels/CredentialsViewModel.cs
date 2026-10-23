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
        private DataTemplate? _currentTemplate;

        public ObservableCollection<CardDesignModel> CardDesigns { get; set; } = new ObservableCollection<CardDesignModel>();

        public DataTemplate? CurrentTemplate
        {
            get => _currentTemplate;
            set { _currentTemplate = value; OnPropertyChanged(); }
        }

        public ICommand SwitchToGridViewCommand { get; }
        public ICommand SwitchToListViewCommand { get; }

        public CredentialsViewModel()
        {
            // ယာယီ Test Data များ ထည့်သွင်းခြင်း
            CardDesigns.Add(new CardDesignModel { DesignName = "Staff ID Card", OwnerUsername = "admin" });
            CardDesigns.Add(new CardDesignModel { DesignName = "Visitor Badge", OwnerUsername = "user1" });
            CardDesigns.Add(new CardDesignModel { DesignName = "Contractor Pass", OwnerUsername = "user1" });

            // Command များ ချိတ်ဆက်ခြင်း
            SwitchToGridViewCommand = new RelayCommand(o => SetViewMode("Grid"));
            SwitchToListViewCommand = new RelayCommand(o => SetViewMode("List"));

            // Default အနေဖြင့် Grid View ဖြင့် စတင်ပြသရန်
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                SetViewMode("Grid");
            });
        }

        private void SetViewMode(string mode)
        {
            if (Application.Current.MainWindow != null && Application.Current.MainWindow.Resources.Contains(mode + "Template"))
            {
                CurrentTemplate = Application.Current.MainWindow.Resources[mode + "Template"] as DataTemplate;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
