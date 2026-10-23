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
            // Sidebar button colors update
            PreferencesNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            PreferencesNavBtn.FontWeight = FontWeights.Bold;

            ChangePasswordNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            ChangePasswordNavBtn.FontWeight = FontWeights.SemiBold;

            // Reload Preferences View Content
            SettingsContentArea.Content = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = new StackPanel
                {
                    Children =
                    {
                        new TextBlock { Text = "Manage Your Preferences", FontSize = 22, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E3A8A")), Margin = new Thickness(0, 0, 0, 15) },
                        // (လိုအပ်ပါက ဤနေရာတွင် အထက်ပါ Preferences UI အပြည့်အစုံကို ထပ်မံထည့်သွင်းနိုင်သည်)
                    }
                }
            };
        }

        private void ChangePasswordTab_Click(object sender, RoutedEventArgs e)
        {
            // Sidebar button colors update
            ChangePasswordNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            ChangePasswordNavBtn.FontWeight = FontWeights.Bold;

            PreferencesNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            PreferencesNavBtn.FontWeight = FontWeights.SemiBold;

            // Change Password Form Content
            var passwordStackPanel = new StackPanel { Margin = new Thickness(10) };
            passwordStackPanel.Children.Add(new TextBlock { Text = "Change Your Password", FontSize = 22, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E3A8A")), Margin = new Thickness(0, 0, 0, 20) });

            passwordStackPanel.Children.Add(new TextBlock { Text = "Current Password", FontWeight = FontWeights.SemiBold, Margin = new Thickness(0, 0, 0, 5) });
            passwordStackPanel.Children.Add(new PasswordBox { Height = 32, Margin = new Thickness(0, 0, 0, 15) });

            passwordStackPanel.Children.Add(new TextBlock { Text = "New Password", FontWeight = FontWeights.SemiBold, Margin = new Thickness(0, 0, 0, 5) });
            passwordStackPanel.Children.Add(new PasswordBox { Height = 32, Margin = new Thickness(0, 0, 0, 15) });

            passwordStackPanel.Children.Add(new TextBlock { Text = "Confirm New Password", FontWeight = FontWeights.SemiBold, Margin = new Thickness(0, 0, 0, 5) });
            passwordStackPanel.Children.Add(new PasswordBox { Height = 32, Margin = new Thickness(0, 0, 0, 20) });

            var saveBtn = new Button { Content = "Update Password", Width = 140, Height = 32, Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB")), Foreground = Brushes.White, FontWeight = FontWeights.Bold };
            passwordStackPanel.Children.Add(saveBtn);

            SettingsContentArea.Content = passwordStackPanel;
        }
    }
}
