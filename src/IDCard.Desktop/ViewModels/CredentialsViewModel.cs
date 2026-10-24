using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;
using IDCard.Desktop.Services;

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
        public ICommand LoadDataCommand { get; }

        public CredentialsViewModel()
        {
            // Database မှ Card Design များကို Load လုပ်ခြင်း
            LoadCardDesignsFromDatabase();

            // Command များ ချိတ်ဆက်ခြင်း
            SwitchToGridViewCommand = new RelayCommand(o => SetViewMode("Grid"));
            SwitchToListViewCommand = new RelayCommand(o => SetViewMode("List"));
            LoadDataCommand = new RelayCommand(o => LoadCardDesignsFromDatabase());

            // Default အနေဖြင့် Grid View ဖြင့် စတင်ပြသရန်
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                SetViewMode("Grid");
            });
        }

        private void LoadCardDesignsFromDatabase()
        {
            try
            {
                using var context = new AppDbContext();
                var designs = context.CardDesigns.ToList();
                
                CardDesigns.Clear();
                foreach (var design in designs)
                {
                    CardDesigns.Add(design);
                }

                // အကယ်၍ Database ထဲတွင် Data လုံးဝမရှိသေးပါက Default များကို ထည့်ပေးနိုင်သည်
                if (CardDesigns.Count == 0)
                {
                    CardDesigns.Add(new CardDesignModel { DesignName = "Staff ID Card", OwnerUsername = "admin" });
                    CardDesigns.Add(new CardDesignModel { DesignName = "Visitor Badge", OwnerUsername = "user1" });
                }
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading card designs: {ex.Message}");
            }
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
