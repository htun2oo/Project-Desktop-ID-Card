using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IDCard.Desktop.Views
{
    public partial class CredentialDesignsView : UserControl
    {
        private bool _isDragging;
        private Point _startPoint;
        private Thickness _startMargin;

        public CredentialDesignsView()
        {
            InitializeComponent();
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isDragging = true;
            _startPoint = e.GetPosition(ParentCanvas);
            _startMargin = DialogBorder.Margin;
            HeaderBorder.CaptureMouse();
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                Point currentPoint = e.GetPosition(ParentCanvas);
                
                double offsetX = currentPoint.X - _startPoint.X;
                double offsetY = currentPoint.Y - _startPoint.Y;

                DialogBorder.Margin = new Thickness(
                    _startMargin.Left + offsetX,
                    _startMargin.Top + offsetY,
                    0, 0
                );
                
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
