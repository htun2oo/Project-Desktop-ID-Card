using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IDCard.Desktop.Views
{
    public partial class CredentialDesignsView : UserControl
    {
        private bool _isDragging;
        private Point _clickPosition;

        public CredentialDesignsView()
        {
            InitializeComponent();
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _clickPosition = e.GetPosition(DialogBorder);
            HeaderBorder.CaptureMouse();
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentPosition = e.GetPosition(ParentCanvas);
                
                double newLeft = currentPosition.X - _clickPosition.X;
                double newTop = currentPosition.Y - _clickPosition.Y;

                DialogBorder.Margin = new Thickness(newLeft, newTop, 0, 0);
                DialogBorder.HorizontalAlignment = HorizontalAlignment.Left;
                DialogBorder.VerticalAlignment = VerticalAlignment.Top;
            }
        }

        private void Header_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isDragging = false;
            HeaderBorder.ReleaseMouseCapture();
        }
    }
}
