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

        // Create New Workflow ခလုတ်သာပြမည့် မျက်နှာပြင်အတွက် (IsEditingWorkflow ၏ ပြောင်းပြန်)
        public bool IsListVisible => !_isEditingWorkflow;

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            // အရေးကြီးချက်: View သို့ စဝင်လိုက်သည်နှင့် Create New Workflow ခလုတ်ကိုပြရန် false ဟု တိကျစွာသတ်မှတ်သည်
            _isEditingWorkflow = false;

            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
            CloseWorkflowCommand = new RelayCommand(ExecuteCloseWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // Create New Workflow ခလုတ်ကို နှိပ်မှသာ Designer မျက်နှာပြင်သို့ သွားရန် true ပြောင်းမည်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow(object obj)
        {
            // Designer မှ Close နှိပ်ပါက Create New Workflow မျက်နှာပြင်သို့ ပြန်လာရန် false ပြောင်းမည်
            IsEditingWorkflow = false;
        }
    }
}
