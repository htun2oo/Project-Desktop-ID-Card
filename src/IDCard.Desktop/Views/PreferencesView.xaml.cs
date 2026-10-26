using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IDCard.Desktop.Views
{
    public partial class PreferencesView : UserControl
    {
        public PreferencesView()
        {
            InitializeComponent();
        }

        private void MenuTab_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                // ဘယ်ဘက် Side Menu ခလုတ်များအားလုံးကို ပုံမှန် မီးခိုးရောင်သို့ ပြောင်းရန်
                foreach (var child in ((StackPanel)clickedButton.Parent).Children)
                {
                    if (child is Button btn)
                    {
                        btn.Background = new SolidColorBrush(Color.FromRgb(234, 234, 234));
                        btn.FontWeight = FontWeights.SemiBold;
                        btn.Margin = new Thickness(0, 0, 0, 2);
                        btn.BorderBrush = Brushes.Transparent;
                        btn.BorderThickness = new Thickness(0);
                    }
                }

                // နှိပ်လိုက်သော ခလုတ်ကို ညာဘက်အဖြူရောင် Content ဧရိယာနှင့် ချိတ်ဆက်ထားပုံပေါ်စေရန်
                clickedButton.Background = Brushes.White;
                clickedButton.FontWeight = FontWeights.Bold;
                clickedButton.Margin = new Thickness(0, 0, -1, 2);
                clickedButton.BorderBrush = Brushes.LightGray;
                clickedButton.BorderThickness = new Thickness(1, 1, 0, 1);

                // ညာဘက် Content ဧရိယာ၏ ခေါင်းစဉ်ကို ပြောင်းလဲပေးရန်
                SectionTitleText.Text = clickedButton.Content?.ToString();
            }
        }

        // MainViewModel မှ လိုအပ်သလို လှမ်းခေါ်ရန် Helper Methods များ
        public void SelectTabByName(string tabName)
        {
            foreach (var child in ((StackPanel)((ScrollViewer)AccessAttributesBtn.Parent).Content).Children)
            {
                if (child is Button btn && btn.Content?.ToString() == tabName)
                {
                    MenuTab_Click(btn, new RoutedEventArgs());
                    break;
                }
            }
        }

        public void SelectPreferencesTab() => SelectTabByName("Application Settings");
        public void SelectChangePasswordTab() => SelectTabByName("Authentication");
    }
}
