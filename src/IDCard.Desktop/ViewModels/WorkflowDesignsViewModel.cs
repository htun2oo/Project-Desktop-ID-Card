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
            // စစချင်း ဝင်လာချိန်တွင် Create New Workflow မျက်နှာပြင်ပြရန် false ဟု သတ်မှတ်သည်
            _isEditingWorkflow = false;

            // Nullability Warnings ကင်းစင်စေရန် Parameter မပါသော Action များကို သုံးသည်
            CreateNewWorkflowCommand = new RelayCommand(_ => ExecuteCreateNewWorkflow());
            CloseWorkflowCommand = new RelayCommand(_ => ExecuteCloseWorkflow());
        }

        private void ExecuteCreateNewWorkflow()
        {
            // Create New Workflow ခလုတ်ကို နှိပ်ပါက Designer မျက်နှာပြင်သို့ ပြောင်းရန်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow()
        {
            // Designer မှ Close နှိပ်ပါက မူလ မျက်နှာပြင်သို့ ပြန်သွားရန်
            IsEditingWorkflow = false;
        }
    }
}
