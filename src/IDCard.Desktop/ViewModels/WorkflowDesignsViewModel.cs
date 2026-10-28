using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class WorkflowDesignsViewModel : ViewModelBase
    {
        private bool _isEditingWorkflow;
        public bool IsEditingWorkflow
        {
            get => _isEditingWorkflow;
            set { _isEditingWorkflow = value; OnPropertyChanged(); }
        }

        public ICommand CreateNewWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // Create New Workflow ခလုတ်နှိပ်လိုက်ပါက Editing View သို့ ပြောင်းရန်
            IsEditingWorkflow = true;
        }
    }
}
