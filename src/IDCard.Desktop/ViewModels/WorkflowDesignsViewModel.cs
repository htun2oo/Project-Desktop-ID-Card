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
            set 
            { 
                if (_isEditingWorkflow != value)
                {
                    _isEditingWorkflow = value; 
                    OnPropertyChanged(); 
                    OnPropertyChanged(nameof(IsListVisible)); 
                }
            }
        }

        // မျက်နှာပြင်စတင်ဖွင့်ချိန်တွင် Create New Workflow ခလုတ်ကိုသာ ပထမဆုံးပြရန်
        public bool IsListVisible => !_isEditingWorkflow;

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            // View အသစ်ဆောက်လိုက်တိုင်း သေချာပေါက် false (Create New Workflow မျက်နှာပြင်) ဖြစ်နေစေရန်
            _isEditingWorkflow = false;

            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
            CloseWorkflowCommand = new RelayCommand(ExecuteCloseWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // "Create New Workflow" ခလုတ်ကို နှိပ်မှသာ Designer သို့ ပြောင်းမည်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow(object obj)
        {
            // Close နှိပ်ပါက Create New Workflow မျက်နှာပြင်သို့ ပြန်သွားမည်
            IsEditingWorkflow = false;
        }
    }
}
