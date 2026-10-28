using System;
using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class WorkflowDesignsViewModel : ViewModelBase
    {
        private readonly Action _enterEditor;
        private readonly Action _exitEditor;

        private bool _isEditingWorkflow;
        public bool IsEditingWorkflow
        {
            get => _isEditingWorkflow;
            set 
            { 
                if (_isEditingWorkflow != value)
                {
                    _isEditingWorkflow = value; 
                    OnPropertyChanged(); 
                }
            }
        }

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;

            _isEditingWorkflow = false;

            CreateNewWorkflowCommand = new RelayCommand(_ => ExecuteCreateNewWorkflow());
            CloseWorkflowCommand = new RelayCommand(_ => ExecuteCloseWorkflow());
        }

        public void ResetToListView()
        {
            _isEditingWorkflow = false;
            OnPropertyChanged(nameof(IsEditingWorkflow));
        }

        private void ExecuteCreateNewWorkflow()
        {
            IsEditingWorkflow = true;
            _enterEditor?.Invoke(); // Main Window ၏ Main Tabs များကို Workflow Design 1 & Properties သို့ ပြောင်းရန် လှမ်းအကြောင်းကြားခြင်း
        }

        private void ExecuteCloseWorkflow()
        {
            IsEditingWorkflow = false;
            _exitEditor?.Invoke(); // မူလ Tab များဆီသို့ ပြန်သွားရန်
        }
    }
}
