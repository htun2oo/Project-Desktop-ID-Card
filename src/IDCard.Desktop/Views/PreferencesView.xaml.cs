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

        public void SelectPreferencesTab()
        {
            PreferencesPanel.Visibility = Visibility.Visible;
            ChangePasswordPanel.Visibility = Visibility.Collapsed;

            PreferencesNavBtn.Background = Brushes.White;
            PreferencesNavBtn.FontWeight = FontWeights.Bold;
            PreferencesNavBtn.Margin = new Thickness(0, 0, -1, 2);
            PreferencesNavBtn.BorderBrush = Brushes.LightGray;
            PreferencesNavBtn.BorderThickness = new Thickness(1, 1, 0, 1);

            ChangePasswordNavBtn.Background = new SolidColorBrush(Color.FromRgb(234, 234, 234));
            ChangePasswordNavBtn.FontWeight = FontWeights.SemiBold;
            ChangePasswordNavBtn.Margin = new Thickness(0, 0, 0, 2);
            ChangePasswordNavBtn.BorderBrush = Brushes.Transparent;
            ChangePasswordNavBtn.BorderThickness = new Thickness(0);
        }

        public void SelectChangePasswordTab()
        {
            PreferencesPanel.Visibility = Visibility.Collapsed;
            ChangePasswordPanel.Visibility = Visibility.Visible;

            ChangePasswordNavBtn.Background = Brushes.White;
            ChangePasswordNavBtn.FontWeight = FontWeights.Bold;
            ChangePasswordNavBtn.Margin = new Thickness(0, 0, -1, 2);
            ChangePasswordNavBtn.BorderBrush = Brushes.LightGray;
            ChangePasswordNavBtn.BorderThickness = new Thickness(1, 1, 0, 1);

            PreferencesNavBtn.Background = new SolidColorBrush(Color.FromRgb(234, 234, 234));
            PreferencesNavBtn.FontWeight = FontWeights.SemiBold;
            PreferencesNavBtn.Margin = new Thickness(0, 0, 0, 2);
            PreferencesNavBtn.BorderBrush = Brushes.Transparent;
            PreferencesNavBtn.BorderThickness = new Thickness(0);
        }

        private void PreferencesNavBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectPreferencesTab();
        }

        private void ChangePasswordNavBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectChangePasswordTab();
        }
    }
}
