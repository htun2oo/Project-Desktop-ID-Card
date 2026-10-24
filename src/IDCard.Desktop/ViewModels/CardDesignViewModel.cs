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
    public class CardDesignViewModel : INotifyPropertyChanged
    {
        private CardDesignModel _currentCard = new CardDesignModel();

        public CardDesignModel CurrentCard
        {
            get => _currentCard;
            set { _currentCard = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        public CardDesignViewModel()
        {
            SaveCommand = new RelayCommand(ExecuteSave);
        }

        // Access Control: Modify လုပ်ခွင့်ရှိမရှိ စစ်ဆေးခြင်း
        private bool CanModifyCard(string ownerUsername)
        {
            // Administrator ဖြစ်ပါက မည်သည့် Card ကိုမဆို လွတ်လပ်စွာ ပြင်ဆင်ခွင့်ရှိသည်
            if (UserSession.IsAdmin)
            {
                return true;
            }

            // Regular User ဖြစ်ပါက ကိုယ်တိုင်ဖန်တီးထားသော Card ဟုတ်မဟုတ် စစ်ဆေးသည်
            return ownerUsername == UserSession.CurrentUser?.Username;
        }

        private void ExecuteSave(object? parameter)
        {
            // အကယ်၍ Card အသစ်ဖြစ်ပါက လက်ရှိဝင်ထားသော User ကို Owner အဖြစ် သတ်မှတ်မည်
            if (string.IsNullOrEmpty(CurrentCard.OwnerUsername))
            {
                CurrentCard.OwnerUsername = UserSession.CurrentUser?.Username ?? "Unknown";
            }

            // Save သို့မဟုတ် Edit မလုပ်မီ ခွင့်ပြုချက် ရှိမရှိ စစ်ဆေးခြင်း
            if (!CanModifyCard(CurrentCard.OwnerUsername))
            {
                MessageBox.Show("Access Denied! You do not have permission to modify this card design.", 
                                "Unauthorized", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using var context = new AppDbContext();
                
                // Database ထဲတွင် ဒီဇိုင်းရှိပြီးသားလား စစ်ဆေးခြင်း (Update or Insert)
                var existingCard = context.CardDesigns.FirstOrDefault(c => c.Id == CurrentCard.Id);
                if (existingCard != null)
                {
                    existingCard.DesignName = CurrentCard.DesignName;
                    existingCard.CardDataJson = CurrentCard.CardDataJson;
                    context.CardDesigns.Update(existingCard);
                }
                else
                {
                    context.CardDesigns.Add(CurrentCard);
                }

                context.SaveChanges();
                MessageBox.Show("Card design saved successfully to database!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error saving card design: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
