namespace IDCard.Desktop.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private string _reportTitle = "System Reports and Analytics";
        public string ReportTitle
        {
            get => _reportTitle;
            set { _reportTitle = value; OnPropertyChanged(); }
        }

        public ReportsViewModel()
        {
            // Reports ဆိုင်ရာ လိုဂျစ်များ ထည့်သွင်းရန်
        }
    }
}
