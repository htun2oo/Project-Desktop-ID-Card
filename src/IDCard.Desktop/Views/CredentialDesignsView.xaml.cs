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
            if (sender is Button button && button.ToolTip is string toolTipText)
            {
                DataObject data = new DataObject("ItemType", toolTipText);
                DragDrop.DoDragDrop(button, data, DragDropEffects.Copy);
            }
        }

        private void PhotoButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataObject data = new DataObject("ItemType", "Photo");
            DragDrop.DoDragDrop((Button)sender, data, DragDropEffects.Copy);
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ItemType"))
            {
                var itemType = e.Data.GetData("ItemType")?.ToString();
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    viewModel.DropItemCommand.Execute(itemType);
                }
            }
        }

        private void TextElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignTextElement clickedElement)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    foreach (var el in viewModel.FrontSideElements) el.IsSelected = false;
                    foreach (var el in viewModel.BackSideElements) el.IsSelected = false;
                    foreach (var ph in viewModel.FrontSidePhotos) ph.IsSelected = false;
                    foreach (var ph in viewModel.BackSidePhotos) ph.IsSelected = false;

                    clickedElement.IsSelected = true;
                    viewModel.IsTextSelected = true;
                    viewModel.IsPhotoSelected = false;
                }
                e.Handled = true;
            }
        }

        private void PhotoElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignPhotoElement clickedPhoto)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    foreach (var el in viewModel.FrontSideElements) el.IsSelected = false;
                    foreach (var el in viewModel.BackSideElements) el.IsSelected = false;
                    foreach (var ph in viewModel.FrontSidePhotos) ph.IsSelected = false;
                    foreach (var ph in viewModel.BackSidePhotos) ph.IsSelected = false;

                    clickedPhoto.IsSelected = true;
                    viewModel.IsTextSelected = false;
                    viewModel.IsPhotoSelected = true;
                }
                e.Handled = true;
            }
        }

        private void CardBackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CredentialDesignsViewModel viewModel)
            {
                viewModel.IsTextSelected = false;
                viewModel.IsPhotoSelected = false;

                foreach (var element in viewModel.FrontSideElements) element.IsSelected = false;
                foreach (var element in viewModel.BackSideElements) element.IsSelected = false;
                foreach (var photo in viewModel.FrontSidePhotos) photo.IsSelected = false;
                foreach (var photo in viewModel.BackSidePhotos) photo.IsSelected = false;
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
