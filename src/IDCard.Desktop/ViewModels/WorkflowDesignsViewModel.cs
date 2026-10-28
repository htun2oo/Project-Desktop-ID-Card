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
                OnPropertyChanged(nameof(IsListVisible)); 
            }
        }

        // စစချင်းဝင်ချင်းတွင် Create New Workflow ခလုတ်ကိုပြရန် True ဖြစ်ရပါမည်
        public bool IsListVisible => !_isEditingWorkflow;

        public ICommand CreateNewWorkflowCommand { get; }
        public ICommand CloseWorkflowCommand { get; }

        public WorkflowDesignsViewModel()
        {
            // အရေးကြီးသည်: စစချင်း ဝင်လာချိန်တွင် Editing မလုပ်သေးသောကြောင့် false ဟัตထားရပါမည်
            _isEditingWorkflow = false;

            CreateNewWorkflowCommand = new RelayCommand(ExecuteCreateNewWorkflow);
            CloseWorkflowCommand = new RelayCommand(ExecuteCloseWorkflow);
        }

        private void ExecuteCreateNewWorkflow(object obj)
        {
            // "Create New Workflow" ခလုတ်ကို နှိပ်မှသာ Designer မျက်နှာပြင်သို့ သွားရန် true ပြောင်းမည်
            IsEditingWorkflow = true;
        }

        private void ExecuteCloseWorkflow(object obj)
        {
            // Designer ထဲမှ Close နှိပ်ပါက မူလ Create New Workflow ခလုတ်ရှိရာ စာမျက်နှာသို့ ပြန်လာရန် false ပြောင်းမည်
            IsEditingWorkflow = false;
        }
    }
}
