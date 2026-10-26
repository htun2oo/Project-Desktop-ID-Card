using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IDCard.Desktop.Views
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void MenuTab_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
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

                clickedButton.Background = Brushes.White;
                clickedButton.FontWeight = FontWeights.Bold;
                clickedButton.Margin = new Thickness(0, 0, -2, 2);
                clickedButton.BorderBrush = Brushes.LightGray;
                clickedButton.BorderThickness = new Thickness(1, 1, 0, 1);

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

        public void SelectPreferencesTab() => SelectTabByName("Preferences");
        public void SelectChangePasswordTab() => SelectTabByName("Change Your Password");
    }
}
