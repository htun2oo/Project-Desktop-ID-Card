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

        private string _selectedSide = "Front";
        public string SelectedSide
        {
            get => _selectedSide;
            set
            {
                if (_selectedSide != value)
                {
                    _selectedSide = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isLayersTabSelected;
        public bool IsLayersTabSelected
        {
            get => _isLayersTabSelected;
            set
            {
                if (_isLayersTabSelected != value)
                {
                    _isLayersTabSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateNewCredentialCommand { get; }
        public ICommand CloseCredentialCommand { get; }
        public ICommand OpenEditPropertiesCommand { get; }
        public ICommand CloseEditPropertiesCommand { get; }
        public ICommand SelectFrontSideCommand { get; }
        public ICommand SelectBackSideCommand { get; }
        public ICommand ShowPropertiesTabCommand { get; }
        public ICommand ShowLayersTabCommand { get; }

        public CredentialDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;
            _isEditingCredential = false;
            _isEditPropertiesOpen = false;
            _selectedSide = "Front";
            _isLayersTabSelected = false;

            CreateNewCredentialCommand = new RelayCommand(_ => {
                _enterEditor?.Invoke();
                IsEditingCredential = true;
            });

            CloseCredentialCommand = new RelayCommand(_ => {
                _exitEditor?.Invoke();
                IsEditingCredential = false;
            });

            OpenEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = true);
            CloseEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = false);

            SelectFrontSideCommand = new RelayCommand(_ => SelectedSide = "Front");
            SelectBackSideCommand = new RelayCommand(_ => SelectedSide = "Back");

            ShowPropertiesTabCommand = new RelayCommand(_ => IsLayersTabSelected = false);
            ShowLayersTabCommand = new RelayCommand(_ => IsLayersTabSelected = true);
        }
    }
}
