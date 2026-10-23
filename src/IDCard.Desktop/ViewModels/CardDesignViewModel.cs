using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;

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

            // ခွင့်ပြုချက်ရှိပါက ဆက်လက် သိမ်းဆည်းခြင်း လုပ်ငန်းစဉ်များ လုပ်ဆောင်ရန်
            MessageBox.Show("Card design saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
