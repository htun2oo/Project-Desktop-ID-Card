using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using IDCard.Desktop.Helpers;
using IDCard.Desktop.Models;
using IDCard.Desktop.Services;

namespace IDCard.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _fullName = string.Empty;
        private string _position = string.Empty;
        private string _department = string.Empty;

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public string Position
        {
            get => _position;
            set { _position = value; OnPropertyChanged(); }
        }

        public string Department
        {
            get => _department;
            set { _department = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }

        public MainViewModel()
        {
            SaveCommand = new RelayCommand(ExecuteSave);
        }

        private void ExecuteSave(object? parameter)
        {
            using var context = new AppDbContext();
            context.Employees.Add(new Employee
            {
                FullName = FullName,
                Position = Position,
                Department = Department
            });
            context.SaveChanges();

            // Form များကို ရှင်းလင်းခြင်း
            FullName = string.Empty;
            Position = string.Empty;
            Department = string.Empty;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
