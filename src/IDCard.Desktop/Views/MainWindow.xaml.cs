using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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

        // Credentials တက်ဘ်ကို နှိပ်သည့်အခါ မူလ Form/Workspace သို့ ပြန်သွားရန်
        private void CredentialsButton_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow.xaml တွင် သတ်မှတ်ထားသော Original Credentials Layout သို့ ပြန်လည်ပြသခြင်း
            // (သို့မဟုတ် MainWindow ကို ယာယီအသစ်ဖွင့်ခြင်း သို့မဟုတ် UserControl အဖြစ် ခွဲထုတ်ခြင်းဖြင့် ချိတ်ဆက်နိုင်ပါသည်)
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        // Reports တက်ဘ်ကို နှိပ်သည့်အခါ Report ကတ်ပြားများ ပေါ်လာစေရန်
        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            var reportsView = new ReportsView();

            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(reportsView, 2);
            MainContentArea.Children.Add(reportsView);
        }
    }
}
