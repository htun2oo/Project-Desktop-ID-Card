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
            // Preferences ကို နှိပ်သည့်အခါ ဒုတိယ/တတိယ ပုံပါ Settings မျက်နှာပြင်သို့ ပြောင်းလဲပြသခြင်း
            var preferencesContent = new Border
            {
                Background = System.Windows.Media.Brushes.White,
                CornerRadius = new CornerRadius(8),
                Padding = new Thickness(25),
                BorderBrush = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#E5E7EB"),
                BorderThickness = new Thickness(1)
            };

            var scrollViewer = new ScrollViewer { VerticalScrollBarVisibility = ScrollBarVisibility.Auto };
            var stackPanel = new StackPanel();

            stackPanel.Children.Add(new TextBlock { Text = "Manage Your Preferences", FontSize = 22, FontWeight = FontWeights.Bold, Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#1E3A8A"), Margin = new Thickness(0, 0, 0, 20) });
            
            // General Preferences
            stackPanel.Children.Add(new TextBlock { Text = "General Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#374151"), Margin = new Thickness(0, 0, 0, 10) });
            stackPanel.Children.Add(new CheckBox { Content = "Display tooltip for license expiration", Margin = new Thickness(0, 0, 0, 8) });
            stackPanel.Children.Add(new CheckBox { Content = "Always show Quick Start on sign in", Margin = new Thickness(0, 0, 0, 8) });
            stackPanel.Children.Add(new CheckBox { Content = "Display training tips for designing a credential", Margin = new Thickness(0, 0, 0, 20) });

            // Printer Preferences
            stackPanel.Children.Add(new TextBlock { Text = "Printer Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#374151"), Margin = new Thickness(0, 0, 0, 10) });
            stackPanel.Children.Add(new CheckBox { Content = "Always prompt for printer", IsChecked = true, Margin = new Thickness(0, 0, 0, 15) });

            // Report Preferences
            stackPanel.Children.Add(new TextBlock { Text = "Report Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFrom("#374151"), Margin = new Thickness(0, 0, 0, 10) });
            
            var reportGrid = new Grid();
            reportGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(250) });
            reportGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });
            
            var lblReport = new TextBlock { Text = "Maximum number of records per report", VerticalAlignment = VerticalAlignment.Center };
            Grid.SetColumn(lblReport, 0);
            reportGrid.Children.Add(lblReport);

            var txtReport = new TextBox { Text = "1000", Height = 28, VerticalContentAlignment = VerticalAlignment.Center };
            Grid.SetColumn(txtReport, 1);
            reportGrid.Children.Add(txtReport);

            stackPanel.Children.Add(reportGrid);

            scrollViewer.Content = stackPanel;
            preferencesContent.Child = scrollViewer;

            // Main Content Area တွင် အစားထိုးပြသရန်
            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(preferencesContent, 2);
            MainContentArea.Children.Add(preferencesContent);
        }
    }
}
