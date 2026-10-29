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

        public ICommand CreateNewCredentialCommand { get; }
        public ICommand CloseCredentialCommand { get; }

        public CredentialDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;
            _isEditingCredential = false;

            CreateNewCredentialCommand = new RelayCommand(_ => ExecuteCreateNewCredential());
            CloseCredentialCommand = new RelayCommand(_ => ExecuteCloseCredential());
        }

        public void ResetToListView()
        {
            _isEditingCredential = false;
            OnPropertyChanged(nameof(IsEditingCredential));
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
