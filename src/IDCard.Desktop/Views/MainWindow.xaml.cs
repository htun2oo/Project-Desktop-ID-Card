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
            // Login Window သို့ ပြန်သွားရန်
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            // Preferences ကို နှိပ်သည့်အခါ သီးသန့်ဖန်တီးထားသော PreferencesView ကို MainContentArea တွင် ခေါ်ယူပြသခြင်း
            var preferencesView = new PreferencesView();

            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(preferencesView, 2);
            MainContentArea.Children.Add(preferencesView);
        }
    }
}
