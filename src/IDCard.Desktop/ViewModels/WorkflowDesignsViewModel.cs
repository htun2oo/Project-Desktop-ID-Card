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
                _isEditingWorkflow = value; 
                OnPropertyChanged(); 
            }
        }

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            // အစပိုင်းတွင် Create New Workflow ခလုတ်ပေါ်သည့် မျက်နှာပြင်ကို ပြရန် false ဟု သတ်မှတ်သည်
            _isEditingWorkflow = false;

            // Command များကို ချိတ်ဆက်ခြင်း
            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
            CloseWorkflowCommand = new RelayCommand(ExecuteCloseWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // Create New Workflow ခလုတ်နှိပ်ပါက Designer မျက်နှာပြင်သို့ သွားရန် true ပြောင်းမည်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow(object obj)
        {
            // Close ခလုတ်နှိပ်ပါက မူလစာမျက်နှာ (Create New Workflow မျက်နှာပြင်) သို့ ပြန်သွားရန် false ပြောင်းမည်
            IsEditingWorkflow = false;
        }
    }
}
