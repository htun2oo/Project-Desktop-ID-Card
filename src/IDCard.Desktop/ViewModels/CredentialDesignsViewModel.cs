using System;
using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class CredentialDesignsViewModel : ViewModelBase
    {
        private readonly Action _enterEditor;
        private readonly Action _exitEditor;

        private bool _isEditingCredential;
        public bool IsEditingCredential
        {
            get => _isEditingCredential;
            set 
            { 
                if (_isEditingCredential != value)
                {
                    _isEditingCredential = value; 
                    OnPropertyChanged(); 
                }
            }
        }

        private bool _isEditPropertiesOpen;
        public bool IsEditPropertiesOpen
        {
            get => _isEditPropertiesOpen;
            set 
            { 
                if (_isEditPropertiesOpen != value)
                {
                    _isEditPropertiesOpen = value; 
                    OnPropertyChanged(); 
                }
            }
        }

        public ICommand CreateNewCredentialCommand { get; }
        public ICommand CloseCredentialCommand { get; }
        public ICommand OpenEditPropertiesCommand { get; }
        public ICommand CloseEditPropertiesCommand { get; }

        public CredentialDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;
            _isEditingCredential = false;
            _isEditPropertiesOpen = false;

            CreateNewCredentialCommand = new RelayCommand(_ => ExecuteCreateNewCredential());
            CloseCredentialCommand = new RelayCommand(_ => ExecuteCloseCredential());
            OpenEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = true);
            CloseEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = false);
        }

        public void ResetToListView()
        {
            _isEditingCredential = false;
            _isEditPropertiesOpen = false;
            OnPropertyChanged(nameof(IsEditingCredential));
            OnPropertyChanged(nameof(IsEditPropertiesOpen));
        }

        private void ExecuteCreateNewCredential()
        {
            IsEditingCredential = true;
            _enterEditor?.Invoke();
        }

        private void ExecuteCloseCredential()
        {
            IsEditingCredential = false;
            _exitEditor?.Invoke();
        }
    }
}
