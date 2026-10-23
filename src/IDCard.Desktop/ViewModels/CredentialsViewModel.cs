namespace IDCard.Desktop.ViewModels
{
    public class CredentialsViewModel : ViewModelBase
    {
        private string _statusMessage = "Manage and issue ID credentials here.";
        public string StatusMessage
        {
            get => _statusMessage;
            set { _statusMessage = value; OnPropertyChanged(); }
        }

        public CredentialsViewModel()
        {
            // Credentials ဆိုင်ရာ လိုဂျစ်များနှင့် Commands များ ထည့်သွင်းရန်
        }
    }
}
