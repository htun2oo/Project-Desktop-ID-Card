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

        private void ToolBarButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button && button.ToolTip is string toolTipText)
            {
                DataObject data = new DataObject("ItemType", toolTipText);
                DragDrop.DoDragDrop(button, data, DragDropEffects.Copy);
            }
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
                    ClearAllSelections(viewModel);
                    clickedElement.IsSelected = true;
                    viewModel.IsTextSelected = true;
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
                    ClearAllSelections(viewModel);
                    clickedPhoto.IsSelected = true;
                    viewModel.IsPhotoSelected = true;
                }
                e.Handled = true;
            }
        }

        private void GraphicElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignGraphicElement clickedGraphic)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    ClearAllSelections(viewModel);
                    clickedGraphic.IsSelected = true;
                    viewModel.IsStaticGraphicSelected = true;
                }
                e.Handled = true;
            }
        }

        private void VarGraphicElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignVariableGraphicElement clickedVarGraphic)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    ClearAllSelections(viewModel);
                    clickedVarGraphic.IsSelected = true;
                    viewModel.IsVariableGraphicSelected = true;
                }
                e.Handled = true;
            }
        }

        private void DateElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignDateElement clickedDate)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    ClearAllSelections(viewModel);
                    clickedDate.IsSelected = true;
                    viewModel.IsDateSelected = true;
                }
                e.Handled = true;
            }
        }

        private void SignatureElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignSignatureElement clickedSig)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    ClearAllSelections(viewModel);
                    clickedSig.IsSelected = true;
                    viewModel.IsSignatureSelected = true;
                }
                e.Handled = true;
            }
        }

        private void BarCodeElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is DesignBarCodeElement clickedBarCode)
            {
                if (DataContext is CredentialDesignsViewModel viewModel)
                {
                    ClearAllSelections(viewModel);
                    clickedBarCode.IsSelected = true;
                    viewModel.IsBarCodeSelected = true;
                }
                e.Handled = true;
            }
        }

        private void CardBackground_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is CredentialDesignsViewModel viewModel)
            {
                ClearAllSelections(viewModel);
            }
        }

        private void ClearAllSelections(CredentialDesignsViewModel viewModel)
        {
            viewModel.IsTextSelected = false;
            viewModel.IsPhotoSelected = false;
            viewModel.IsStaticGraphicSelected = false;
            viewModel.IsVariableGraphicSelected = false;
            viewModel.IsDateSelected = false;
            viewModel.IsSignatureSelected = false;
            viewModel.IsBarCodeSelected = false;

            foreach (var el in viewModel.FrontSideElements) el.IsSelected = false;
            foreach (var el in viewModel.BackSideElements) el.IsSelected = false;
            foreach (var ph in viewModel.FrontSidePhotos) ph.IsSelected = false;
            foreach (var ph in viewModel.BackSidePhotos) ph.IsSelected = false;
            foreach (var gr in viewModel.FrontSideGraphics) gr.IsSelected = false;
            foreach (var gr in viewModel.BackSideGraphics) gr.IsSelected = false;
            foreach (var vg in viewModel.FrontSideVarGraphics) vg.IsSelected = false;
            foreach (var vg in viewModel.BackSideVarGraphics) vg.IsSelected = false;
            foreach (var dt in viewModel.FrontSideDates) dt.IsSelected = false;
            foreach (var dt in viewModel.BackSideDates) dt.IsSelected = false;
            foreach (var sg in viewModel.FrontSideSignatures) sg.IsSelected = false;
            foreach (var sg in viewModel.BackSideSignatures) sg.IsSelected = false;
            foreach (var bc in viewModel.FrontSideBarCodes) bc.IsSelected = false;
            foreach (var bc in viewModel.BackSideBarCodes) bc.IsSelected = false;
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
