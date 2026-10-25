using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;
using IDCard.Desktop.Services;

namespace IDCard.Desktop.ViewModels
{
    public class CredentialsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CardDesignModel> CardDesigns { get; set; } = new ObservableCollection<CardDesignModel>();

        public ICommand LoadDataCommand { get; }

        public CredentialsViewModel()
        {
            LoadCardDesignsFromDatabase();
            LoadDataCommand = new RelayCommand(o => LoadCardDesignsFromDatabase());
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
