using System;
using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class ReportDesignsViewModel : ViewModelBase
    {
        private readonly Action _enterEditor;
        private readonly Action _exitEditor;

        private bool _isEditingReport;
        public bool IsEditingReport
        {
            get => _isEditingReport;
            set 
            { 
                if (_isEditingReport != value)
                {
                    _isEditingReport = value; 
                    OnPropertyChanged(); 
                }
            }
        }

        public ICommand CreateNewReportCommand { get; }
        public ICommand CloseReportCommand { get; }

        public ReportDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;
            _isEditingReport = false;

            CreateNewReportCommand = new RelayCommand(_ => ExecuteCreateNewReport());
            CloseReportCommand = new RelayCommand(_ => ExecuteCloseReport());
        }

        public void ResetToListView()
        {
            _isEditingReport = false;
            OnPropertyChanged(nameof(IsEditingReport));
        }

        private void ExecuteCreateNewReport()
        {
            IsEditingReport = true;
            _enterEditor?.Invoke();
        }

        private void ExecuteCloseReport()
        {
            IsEditingReport = false;
            _exitEditor?.Invoke();
        }
    }
}
