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
                OnPropertyChanged(nameof(IsListVisible)); // ပြောင်းလဲမှုကို View သို့ အကြောင်းကြားရန်
            }
        }

        // Create New Workflow ခလုတ်ပါသော ပထမစာမျက်နှာ ပြသရန် (IsEditingWorkflow ၏ ပြောင်းပြန်)
        public bool IsListVisible => !_isEditingWorkflow;

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            // အစပိုင်းတွင် Create New Workflow ခလုတ်ပါသည့် စာမျက်နှာကို ပြရန် false ဟု သတ်မှတ်သည်
            _isEditingWorkflow = false;

            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
            CloseWorkflowCommand = new RelayCommand(ExecuteCloseWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // ခလုတ်နှိပ်ပါက Designer မျက်နှာပြင်သို့ ပြောင်းရန်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow(object obj)
        {
            // Close နှိပ်ပါက မူလစာမျက်နှာသို့ ပြန်သွားရန်
            IsEditingWorkflow = false;
        }
    }
}
