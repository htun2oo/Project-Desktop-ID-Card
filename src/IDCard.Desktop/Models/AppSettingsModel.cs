namespace IDCard.Desktop.Models
{
    public class AppSettingsModel
    {
        public bool DisplayLicenseTooltip { get; set; }
        public bool AlwaysShowQuickStart { get; set; } = true;
        public bool DisplayTrainingTips { get; set; }
        public string SelectedPrinter { get; set; } = string.Empty;
        public bool AlwaysPromptPrinter { get; set; } = true;
        public string Hopper { get; set; } = string.Empty;
        public bool AlwaysConfirmQuickStartExit { get; set; } = true;
        public int MaxRecordsPerReport { get; set; } = 1000;
    }
}
