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

        private void PreferencesTab_Click(object sender, RoutedEventArgs e)
        {
            PreferencesNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            PreferencesNavBtn.FontWeight = FontWeights.Bold;

            ChangePasswordNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            ChangePasswordNavBtn.FontWeight = FontWeights.SemiBold;

            PreferencesPanel.Visibility = Visibility.Visible;
            ChangePasswordPanel.Visibility = Visibility.Collapsed;
        }

        private void ChangePasswordTab_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            ChangePasswordNavBtn.FontWeight = FontWeights.Bold;

            PreferencesNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            PreferencesNavBtn.FontWeight = FontWeights.SemiBold;

            ChangePasswordPanel.Visibility = Visibility.Visible;
            PreferencesPanel.Visibility = Visibility.Collapsed;
        }
    }
}
