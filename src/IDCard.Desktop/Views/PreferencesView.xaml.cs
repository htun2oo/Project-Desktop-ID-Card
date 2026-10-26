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
                // မီနူးတက်ဘ်များအားလုံးကို Inactive (မီးခိုးရောင်) အဖြစ်သို့ ပြောင်းလဲခြင်း
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

                // နှိပ်လိုက်သော တက်ဘ်ကို Active ပြုလုပ်ပြီး ညာဘက်အဖြူရောင်ဧရိယာနှင့် ချိတ်ဆက်ပြသခြင်း
                clickedButton.Background = Brushes.White;
                clickedButton.FontWeight = FontWeights.Bold;
                clickedButton.Margin = new Thickness(0, 0, -1, 2);
                clickedButton.BorderBrush = Brushes.LightGray;
                clickedButton.BorderThickness = new Thickness(1, 1, 0, 1);

                // ညာဘက် Content ခေါင်းစဉ်ကို ပြောင်းလဲပေးခြင်း
                if (SectionTitleText != null && clickedButton.Content != null)
                {
                    SectionTitleText.Text = clickedButton.Content.ToString();
                }
            }
        }

        public void SelectTabByName(string tabName)
        {
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
        public void SelectChangePasswordTab() => SelectTabByName("Change Your Password");
    }
}
