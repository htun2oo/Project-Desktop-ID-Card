using System.Windows;

namespace IDCard.Desktop.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            private void AdminButton_Click(object sender, RoutedEventArgs e)
            {
                if (sender is Button btn && btn.ContextMenu != null)
                {
                    btn.ContextMenu.PlacementTarget = btn;
                    btn.ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                    btn.ContextMenu.IsOpen = true;
                }
            }
        }
    }
}
