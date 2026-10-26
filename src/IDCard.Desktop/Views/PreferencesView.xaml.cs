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
                // ဘယ်ဘက် Side Menu ခလုတ်များအားလုံး၏ နောက်ခံအရောင်နှင့် ပုံစံများကို ပုံမှန်အခြေအနေသို့ ပြန်ပြောင်းရန်
                if (clickedButton.Parent is StackPanel panel)
                {
                    foreach (var child in panel.Children)
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
                }

                // နှိပ်လိုက်သော ခလုတ်ကို ညာဘက်အဖြူရောင် Content ဧရိယာနှင့် ချိတ်ဆက်ထားပုံပေါ်စေရန်
                clickedButton.Background = Brushes.White;
                clickedButton.FontWeight = FontWeights.Bold;
                clickedButton.Margin = new Thickness(0, 0, -1, 2);
                clickedButton.BorderBrush = Brushes.LightGray;
                clickedButton.BorderThickness = new Thickness(1, 1, 0, 1);

                // ညာဘက် Content ဧရိယာ၏ ခေါင်းစဉ်ကို ပြောင်းလဲပေးရန်
                if (SectionTitleText != null && clickedButton.Content != null)
                {
                    SectionTitleText.Text = clickedButton.Content.ToString();
                }
            }
        }

        // မီနူးအမည်အလိုက် တက်ဘ်ကို အမှားအယွင်းကင်းကင်း ရွေးချယ်ပေးမည့် မီသုဒ်
        public void SelectTabByName(string tabName)
        {
            // AccessAttributesBtn သို့မဟုတ် မည်သည့်ခလုတ်မှတစ်ဆင့်မဆို StackPanel ကို လုံခြုံစွာ ရှာဖွေခြင်း
            if (AccessAttributesBtn?.Parent is StackPanel panel)
            {
                foreach (var child in panel.Children)
                {
                    if (child is Button btn && btn.Content?.ToString() == tabName)
                    {
                        MenuTab_Click(btn, new RoutedEventArgs());
                        break;
                    }
                }
            }
        }

        public void SelectPreferencesTab() => SelectTabByName("Application Settings");
        public void SelectChangePasswordTab() => SelectTabByName("Authentication");
    }
}
