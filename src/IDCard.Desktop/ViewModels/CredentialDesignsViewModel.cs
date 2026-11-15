using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IDCard.Desktop.Helpers;

namespace IDCard.Desktop.ViewModels
{
    public class DesignTextElement : ViewModelBase
    {
        private string _text = "Text Field";
        public string Text
        {
            get => _text;
            set { _text = value; OnPropertyChanged(); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set 
            { 
                if (_isSelected != value)
                {
                    _isSelected = value; 
                    OnPropertyChanged(); 
                }
            }
        }
    }

    public class DesignPhotoElement : ViewModelBase
    {
        private bool _isSelected = true;
        public bool IsSelected
        {
            get => _isSelected;
            set 
            { 
                if (_isSelected != value)
                {
                    _isSelected = value; 
                    OnPropertyChanged(); 
                }
            }
        }
    }

    public class CredentialDesignsViewModel : ViewModelBase
    {
        private readonly Action _enterEditor;
        private readonly Action _exitEditor;

        private bool _isEditingCredential;
        public bool IsEditingCredential
        {
            get => _isEditingCredential;
            set { if (_isEditingCredential != value) { _isEditingCredential = value; OnPropertyChanged(); } }
        }

        private bool _isEditPropertiesOpen;
        public bool IsEditPropertiesOpen
        {
            get => _isEditPropertiesOpen;
            set { if (_isEditPropertiesOpen != value) { _isEditPropertiesOpen = value; OnPropertyChanged(); } }
        }

        private string _selectedSide = "Front";
        public string SelectedSide
        {
            get => _selectedSide;
            set { if (_selectedSide != value) { _selectedSide = value; OnPropertyChanged(); } }
        }

        private bool _isLayersTabSelected;
        public bool IsLayersTabSelected
        {
            get => _isLayersTabSelected;
            set { if (_isLayersTabSelected != value) { _isLayersTabSelected = value; OnPropertyChanged(); } }
        }

        private bool _isTextSelected;
        public bool IsTextSelected
        {
            get => _isTextSelected;
            set { if (_isTextSelected != value) { _isTextSelected = value; OnPropertyChanged(); } }
        }

        private bool _isPhotoSelected;
        public bool IsPhotoSelected
        {
            get => _isPhotoSelected;
            set { if (_isPhotoSelected != value) { _isPhotoSelected = value; OnPropertyChanged(); } }
        }

        public ObservableCollection<DesignTextElement> FrontSideElements { get; } = new ObservableCollection<DesignTextElement>();
        public ObservableCollection<DesignTextElement> BackSideElements { get; } = new ObservableCollection<DesignTextElement>();
        
        public ObservableCollection<DesignPhotoElement> FrontSidePhotos { get; } = new ObservableCollection<DesignPhotoElement>();
        public ObservableCollection<DesignPhotoElement> BackSidePhotos { get; } = new ObservableCollection<DesignPhotoElement>();

        public ICommand CreateNewCredentialCommand { get; }
        public ICommand CloseCredentialCommand { get; }
        public ICommand OpenEditPropertiesCommand { get; }
        public ICommand CloseEditPropertiesCommand { get; }
        public ICommand SelectFrontSideCommand { get; }
        public ICommand SelectBackSideCommand { get; }
        public ICommand ShowPropertiesTabCommand { get; }
        public ICommand ShowLayersTabCommand { get; }
        public ICommand DropItemCommand { get; }

        public CredentialDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;

            CreateNewCredentialCommand = new RelayCommand(_ => { IsEditingCredential = true; _enterEditor?.Invoke(); });
            CloseCredentialCommand = new RelayCommand(_ => { IsEditingCredential = false; _exitEditor?.Invoke(); });
            OpenEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = true);
            CloseEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = false);
            SelectFrontSideCommand = new RelayCommand(_ => SelectedSide = "Front");
            SelectBackSideCommand = new RelayCommand(_ => SelectedSide = "Back");
            ShowPropertiesTabCommand = new RelayCommand(_ => IsLayersTabSelected = false);
            ShowLayersTabCommand = new RelayCommand(_ => IsLayersTabSelected = true);
            DropItemCommand = new RelayCommand(parameter => ExecuteDropItem(parameter));
        }

        public void ResetToListView()
        {
            IsEditingCredential = false;
            IsEditPropertiesOpen = false;
            SelectedSide = "Front";
            IsLayersTabSelected = false;
            IsTextSelected = false;
            IsPhotoSelected = false;
            FrontSideElements.Clear();
            BackSideElements.Clear();
            FrontSidePhotos.Clear();
            BackSidePhotos.Clear();
        }

        private void ExecuteDropItem(object? parameter)
        {
            if (parameter is string itemType)
            {
                foreach (var el in FrontSideElements) el.IsSelected = false;
                foreach (var el in BackSideElements) el.IsSelected = false;
                foreach (var ph in FrontSidePhotos) ph.IsSelected = false;
                foreach (var ph in BackSidePhotos) ph.IsSelected = false;

                IsTextSelected = false;
                IsPhotoSelected = false;

                if (itemType == "Photo")
                {
                    var newPhoto = new DesignPhotoElement { IsSelected = true };
                    IsPhotoSelected = true;

                    if (SelectedSide == "Front") FrontSidePhotos.Add(newPhoto);
                    else BackSidePhotos.Add(newPhoto);
                }
                else
                {
                    string defaultText;
                    if (itemType.Contains("Static"))
                    {
                        defaultText = "Static Text Field";
                    }
                    else if (itemType.Contains("Dynamic"))
                    {
                        defaultText = "Dynamic Text Field";
                    }
                    else
                    {
                        defaultText = "Text Field";
                    }

                    var newText = new DesignTextElement { Text = defaultText, IsSelected = true };
                    IsTextSelected = true;

                    if (SelectedSide == "Front") FrontSideElements.Add(newText);
                    else BackSideElements.Add(newText);
                }
            }
        }
    }
}
