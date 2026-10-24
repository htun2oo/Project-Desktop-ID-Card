using System.Windows;
using System.Windows.Controls;

namespace IDCard.Desktop.Views
{
    public partial class PreferencesView : UserControl
    {
        public PreferencesView()
        {
            InitializeComponent();
        }

        private void PreferencesTab_Click(object sender, RoutedEventArgs e)
        {
            // ModernWPF Accent Style ကို Preferences Button သို့ ပြန်လည်သတ်မှတ်ခြင်း
            PreferencesNavBtn.SetResourceReference(StyleProperty, "AccentButtonStyle");
            PreferencesNavBtn.FontWeight = FontWeights.Bold;

            // Change Password Button ကို Default ပုံစံသို့ ပြောင်းခြင်း
            ChangePasswordNavBtn.ClearValue(StyleProperty);
            ChangePasswordNavBtn.Background = System.Windows.Media.Brushes.Transparent;
            ChangePasswordNavBtn.FontWeight = FontWeights.SemiBold;

            PreferencesPanel.Visibility = Visibility.Visible;
            ChangePasswordPanel.Visibility = Visibility.Collapsed;
        }

        private void ChangePasswordTab_Click(object sender, RoutedEventArgs e)
        {
            // ModernWPF Accent Style ကို Change Password Button သို့ ပြန်လည်သတ်မှတ်ခြင်း
            ChangePasswordNavBtn.SetResourceReference(StyleProperty, "AccentButtonStyle");
            ChangePasswordNavBtn.FontWeight = FontWeights.Bold;

            // Preferences Button ကို Default ပုံစံသို့ ပြောင်းခြင်း
            PreferencesNavBtn.ClearValue(StyleProperty);
            PreferencesNavBtn.Background = System.Windows.Media.Brushes.Transparent;
            PreferencesNavBtn.FontWeight = FontWeights.SemiBold;

            ChangePasswordPanel.Visibility = Visibility.Visible;
            PreferencesPanel.Visibility = Visibility.Collapsed;
        }
    }
}
