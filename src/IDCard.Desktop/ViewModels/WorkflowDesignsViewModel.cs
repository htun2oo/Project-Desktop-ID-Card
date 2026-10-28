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
                }
            }
        }

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            // စစချင်းဝင်ချင်းတွင် Create New Workflow ခလုတ်မျက်နှာပြင်ကို ပြရန် false ဟု သတ်မှတ်သည်
            _isEditingWorkflow = false;

            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
            CloseWorkflowCommand = new RelayCommand(ExecuteCloseWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // "Create New Workflow" ခလုတ်နှိပ်ပါက Designer မျက်နှာပြင်သို့ ပြောင်းရန် true သို့ ပြောင်းမည်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow(object obj)
        {
            // Designer မှ Close နှိပ်ပါက မူလ Create New Workflow ခလုတ်ရှိရာ မျက်နှာပြင်သို့ ပြန်သွားရန် false သို့ ပြောင်းမည်
            IsEditingWorkflow = false;
        }
    }
}
