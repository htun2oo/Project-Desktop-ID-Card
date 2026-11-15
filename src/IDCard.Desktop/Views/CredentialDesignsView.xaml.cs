using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IDCard.Desktop.ViewModels;

namespace IDCard.Desktop.Views
{
    public partial class CredentialDesignsView : UserControl
    {
        public CredentialDesignsView()
        {
            InitializeComponent();
        }

        private void TextButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                string textType = button.ToolTip?.ToString(); // "Dynamic Text" သို့မဟုတ် "Static Text"
                DataObject data = new DataObject("TextType", textType);
                DragDrop.DoDragDrop(button, data, DragDropEffects.Copy);
            }
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("TextType"))
            {
                string textType = e.Data.GetData("TextType") as string;

                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    viewModel.DropTextCommand.Execute(textType);
                }
            }
        }

        // Draggable Header Logic for Dialog
        private bool isDragging = false;
        private Point clickPosition;

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            clickPosition = e.GetPosition(ParentCanvas);
            if (sender is UIElement element)
            {
                element.CaptureMouse();
            }
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPosition = e.GetPosition(ParentCanvas);
                Vector diff = currentPosition - clickPosition;
                clickPosition = currentPosition;

                double newLeft = Canvas.GetLeft(DialogBorder) + diff.X;
                double newTop = Canvas.GetTop(DialogBorder) + diff.Y;

                Canvas.SetLeft(DialogBorder, newLeft);
                Canvas.SetTop(DialogBorder, newTop);
            }
        }

        private void Header_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            if (sender is UIElement element)
            {
                element.ReleaseMouseCapture();
            }
        }
    }
}
