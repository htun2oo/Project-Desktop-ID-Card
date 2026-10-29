using System;
using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class FieldConnectionDesignsViewModel : ViewModelBase
    {
        private readonly Action _enterEditor;
        private readonly Action _exitEditor;

        private bool _isEditing;
        public bool IsEditing
        {
            get => _isEditing;
            set 
            { 
                if (_isEditing != value)
                {
                    _isEditing = value; 
                    OnPropertyChanged(); 
                }
            }
        }

        public ICommand OpenEditorCommand { get; }
        public ICommand CloseEditorCommand { get; }

        public FieldConnectionDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;
            _isEditing = false;

            OpenEditorCommand = new RelayCommand(_ => ExecuteOpenEditor());
            CloseEditorCommand = new RelayCommand(_ => ExecuteCloseEditor());
        }

        public void ResetToListView()
        {
            _isEditing = false;
            OnPropertyChanged(nameof(IsEditing));
        }

        private void ExecuteOpenEditor()
        {
            IsEditing = true;
            _enterEditor?.Invoke();
        }

        private void ExecuteCloseEditor()
        {
            IsEditing = false;
            _exitEditor?.Invoke();
        }
    }
}
