using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
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
        private string _photoPath = string.Empty;
        private Employee? _selectedEmployee;

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

        public string PhotoPath
        {
            get => _photoPath;
            set { _photoPath = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Employee> Employees { get; set; } = new();

        public Employee? SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                if (_selectedEmployee != null)
                {
                    FullName = _selectedEmployee.FullName;
                    Position = _selectedEmployee.Position;
                    Department = _selectedEmployee.Department;
                    PhotoPath = _selectedEmployee.PhotoPath;
                }
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand BrowsePhotoCommand { get; }

        public MainViewModel()
        {
            SaveCommand = new RelayCommand(ExecuteSave);
            DeleteCommand = new RelayCommand(ExecuteDelete, CanExecuteDelete);
            BrowsePhotoCommand = new RelayCommand(ExecuteBrowsePhoto);
            
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            using var context = new AppDbContext();
            Employees.Clear();
            foreach (var emp in context.Employees)
            {
                Employees.Add(emp);
            }
        }

        private void ExecuteBrowsePhoto(object? parameter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                PhotoPath = openFileDialog.FileName;
            }
        }

        private void ExecuteSave(object? parameter)
        {
            using var context = new AppDbContext();
            if (SelectedEmployee == null)
            {
                // Create New
                var newEmp = new Employee
                {
                    FullName = FullName,
                    Position = Position,
                    Department = Department,
                    PhotoPath = PhotoPath
                };
                context.Employees.Add(newEmp);
            }
            else
            {
                // Update Existing
                var empToUpdate = context.Employees.Find(SelectedEmployee.Id);
                if (empToUpdate != null)
                {
                    empToUpdate.FullName = FullName;
                    empToUpdate.Position = Position;
                    empToUpdate.Department = Department;
                    empToUpdate.PhotoPath = PhotoPath;
                }
            }
            context.SaveChanges();
            LoadEmployees();
            ClearForm();
        }

        private bool CanExecuteDelete(object? parameter) => SelectedEmployee != null;

        private void ExecuteDelete(object? parameter)
        {
            if (SelectedEmployee != null)
            {
                using var context = new AppDbContext();
                var emp = context.Employees.Find(SelectedEmployee.Id);
                if (emp != null)
                {
                    context.Employees.Remove(emp);
                    context.SaveChanges();
                }
                LoadEmployees();
                ClearForm();
            }
        }

        private void ClearForm()
        {
            FullName = string.Empty;
            Position = string.Empty;
            Department = string.Empty;
            PhotoPath = string.Empty;
            SelectedEmployee = null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
