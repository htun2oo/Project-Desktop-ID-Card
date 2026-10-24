using System.Linq;
using IDCard.Desktop.Services;

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

        private int _totalEmployees;
        public int TotalEmployees
        {
            get => _totalEmployees;
            set { _totalEmployees = value; OnPropertyChanged(); }
        }

        private int _totalCardDesigns;
        public int TotalCardDesigns
        {
            get => _totalCardDesigns;
            set { _totalCardDesigns = value; OnPropertyChanged(); }
        }

        public ReportsViewModel()
        {
            LoadReportData();
        }

        private void LoadReportData()
        {
            try
            {
                using var context = new AppDbContext();
                TotalEmployees = context.Employees.Count();
                TotalCardDesigns = context.CardDesigns.Count();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Report Error: {ex.Message}");
            }
        }
    }
}
