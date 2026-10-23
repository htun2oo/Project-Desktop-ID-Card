using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace IDCard.Desktop.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.ContextMenu != null)
            {
                btn.ContextMenu.PlacementTarget = btn;
                btn.ContextMenu.Placement = PlacementMode.Bottom;
                btn.ContextMenu.IsOpen = true;
            }
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            var preferencesView = new PreferencesView();

            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(preferencesView, 2);
            MainContentArea.Children.Add(preferencesView);
        }

        // Credentials Tab Click Handler
        private void CredentialsButton_Click(object sender, RoutedEventArgs e)
        {
            // Tab Active အရောင်များ ချိန်ညှိခြင်း
            CredentialsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            CredentialsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B21A8"));

            ReportsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#581C87"));
            ReportsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

            // MainContentArea တွင် Credentials Workspace ကို ပြန်လည်ပြသခြင်း
            var mainWindowInstance = new MainWindow();
            // (သို့မဟုတ် ယာယီ MainContentArea အကြောင်းအရာများကို ပြန်ထည့်ခြင်း)
            this.Content = mainWindowInstance.Content;
        }

        // Reports Tab Click Handler
        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            // Tab Active အရောင်များ ချိန်ညှိခြင်း (Reports Active ဖြစ်နေစဉ်)
            ReportsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            ReportsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B21A8"));

            CredentialsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#581C87"));
            CredentialsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

            // ReportsView ကို ထည့်သွင်းပြသခြင်း
            var reportsView = new ReportsView();

            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(reportsView, 2);
            MainContentArea.Children.Add(reportsView);
        }
    }
}
