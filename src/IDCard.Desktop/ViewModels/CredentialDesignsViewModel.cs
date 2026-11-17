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
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }
    }

    public class DesignGraphicElement : ViewModelBase
    {
        private bool _isSelected = true;
        public bool IsSelected
        {
            get => _isSelected;
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }
    }

    public class DesignVariableGraphicElement : ViewModelBase
    {
        private bool _isSelected = true;
        public bool IsSelected
        {
            get => _isSelected;
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }
    }

    public class DesignDateElement : ViewModelBase
    {
        private string _dateText = "11/15/2026 06:51:20 PM";
        public string DateText
        {
            get => _dateText;
            set { if (_dateText != value) { _dateText = value; OnPropertyChanged(); } }
        }

        private bool _isSelected = true;
        public bool IsSelected
        {
            get => _isSelected;
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }
    }

    public class DesignSignatureElement : ViewModelBase
    {
        private bool _isSelected = true;
        public bool IsSelected
        {
            get => _isSelected;
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
        }
    }

    public class DesignBarCodeElement : ViewModelBase
    {
        private bool _isSelected = true;
        public bool IsSelected
        {
            get => _isSelected;
            set { if (_isSelected != value) { _isSelected = value; OnPropertyChanged(); } }
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

        private bool _isStaticGraphicSelected;
        public bool IsStaticGraphicSelected
        {
            get => _isStaticGraphicSelected;
            set { if (_isStaticGraphicSelected != value) { _isStaticGraphicSelected = value; OnPropertyChanged(); } }
        }

        private bool _isVariableGraphicSelected;
        public bool IsVariableGraphicSelected
        {
            get => _isVariableGraphicSelected;
            set { if (_isVariableGraphicSelected != value) { _isVariableGraphicSelected = value; OnPropertyChanged(); } }
        }

        private bool _isDateSelected;
        public bool IsDateSelected
        {
            get => _isDateSelected;
            set { if (_isDateSelected != value) { _isDateSelected = value; OnPropertyChanged(); } }
        }

        private bool _isSignatureSelected;
        public bool IsSignatureSelected
        {
            get => _isSignatureSelected;
            set { if (_isSignatureSelected != value) { _isSignatureSelected = value; OnPropertyChanged(); } }
        }

        private bool _isBarCodeSelected;
        public bool IsBarCodeSelected
        {
            get => _isBarCodeSelected;
            set { if (_isBarCodeSelected != value) { _isBarCodeSelected = value; OnPropertyChanged(); } }
        }

        // Expand/Collapse states for General and Appearance
        private bool _isGeneralExpanded = true;
        public bool IsGeneralExpanded
        {
            get => _isGeneralExpanded;
            set { if (_isGeneralExpanded != value) { _isGeneralExpanded = value; OnPropertyChanged(); } }
        }

        private bool _isAppearanceExpanded = false;
        public bool IsAppearanceExpanded
        {
            get => _isAppearanceExpanded;
            set { if (_isAppearanceExpanded != value) { _isAppearanceExpanded = value; OnPropertyChanged(); } }
        }

        // Active Text Field Properties for General Section
        private string _selectedFieldName = "Dynamic Text Field 1";
        public string SelectedFieldName
        {
            get => _selectedFieldName;
            set { if (_selectedFieldName != value) { _selectedFieldName = value; OnPropertyChanged(); } }
        }

        private string _selectedFieldSampleData = "Dynamic Text Field";
        public string SelectedFieldSampleData
        {
            get => _selectedFieldSampleData;
            set { if (_selectedFieldSampleData != value) { _selectedFieldSampleData = value; OnPropertyChanged(); } }
        }

        private double _left = 1.6188;
        public double Left
        {
            get => _left;
            set { if (_left != value) { _left = value; OnPropertyChanged(); } }
        }

        private double _top = 0.8953;
        public double Top
        {
            get => _top;
            set { if (_top != value) { _top = value; OnPropertyChanged(); } }
        }

        public ObservableCollection<DesignTextElement> FrontSideElements { get; } = new ObservableCollection<DesignTextElement>();
        public ObservableCollection<DesignTextElement> BackSideElements { get; } = new ObservableCollection<DesignTextElement>();
        
        public ObservableCollection<DesignPhotoElement> FrontSidePhotos { get; } = new ObservableCollection<DesignPhotoElement>();
        public ObservableCollection<DesignPhotoElement> BackSidePhotos { get; } = new ObservableCollection<DesignPhotoElement>();

        public ObservableCollection<DesignGraphicElement> FrontSideGraphics { get; } = new ObservableCollection<DesignGraphicElement>();
        public ObservableCollection<DesignGraphicElement> BackSideGraphics { get; } = new ObservableCollection<DesignGraphicElement>();

        public ObservableCollection<DesignVariableGraphicElement> FrontSideVarGraphics { get; } = new ObservableCollection<DesignVariableGraphicElement>();
        public ObservableCollection<DesignVariableGraphicElement> BackSideVarGraphics { get; } = new ObservableCollection<DesignVariableGraphicElement>();

        public ObservableCollection<DesignDateElement> FrontSideDates { get; } = new ObservableCollection<DesignDateElement>();
        public ObservableCollection<DesignDateElement> BackSideDates { get; } = new ObservableCollection<DesignDateElement>();

        public ObservableCollection<DesignSignatureElement> FrontSideSignatures { get; } = new ObservableCollection<DesignSignatureElement>();
        public ObservableCollection<DesignSignatureElement> BackSideSignatures { get; } = new ObservableCollection<DesignSignatureElement>();

        public ObservableCollection<DesignBarCodeElement> FrontSideBarCodes { get; } = new ObservableCollection<DesignBarCodeElement>();
        public ObservableCollection<DesignBarCodeElement> BackSideBarCodes { get; } = new ObservableCollection<DesignBarCodeElement>();

        public ICommand CreateNewCredentialCommand { get; }
        public ICommand CloseCredentialCommand { get; }
        public ICommand OpenEditPropertiesCommand { get; }
        public ICommand CloseEditPropertiesCommand { get; }
        public ICommand SelectFrontSideCommand { get; }
        public ICommand SelectBackSideCommand { get; }
        public ICommand ShowPropertiesTabCommand { get; }
        public ICommand ShowLayersTabCommand { get; }
        public ICommand DropItemCommand { get; }
        public ICommand ToggleGeneralCommand { get; }
        public ICommand ToggleAppearanceCommand { get; }

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

            ToggleGeneralCommand = new RelayCommand(_ => IsGeneralExpanded = !IsGeneralExpanded);
            ToggleAppearanceCommand = new RelayCommand(_ => IsAppearanceExpanded = !IsAppearanceExpanded);
        }

        public void ResetToListView()
        {
            IsEditingCredential = false;
            IsEditPropertiesOpen = false;
            SelectedSide = "Front";
            IsLayersTabSelected = false;
            IsTextSelected = false;
            IsPhotoSelected = false;
            IsStaticGraphicSelected = false;
            IsVariableGraphicSelected = false;
            IsDateSelected = false;
            IsSignatureSelected = false;
            IsBarCodeSelected = false;
            IsGeneralExpanded = true;
            IsAppearanceExpanded = false;

            FrontSideElements.Clear();
            BackSideElements.Clear();
            FrontSidePhotos.Clear();
            BackSidePhotos.Clear();
            FrontSideGraphics.Clear();
            BackSideGraphics.Clear();
            FrontSideVarGraphics.Clear();
            BackSideVarGraphics.Clear();
            FrontSideDates.Clear();
            BackSideDates.Clear();
            FrontSideSignatures.Clear();
            BackSideSignatures.Clear();
            FrontSideBarCodes.Clear();
            BackSideBarCodes.Clear();
        }

        private void ExecuteDropItem(object? parameter)
        {
            if (parameter is string itemType)
            {
                foreach (var el in FrontSideElements) el.IsSelected = false;
                foreach (var el in BackSideElements) el.IsSelected = false;
                foreach (var ph in FrontSidePhotos) ph.IsSelected = false;
                foreach (var ph in BackSidePhotos) ph.IsSelected = false;
                foreach (var gr in FrontSideGraphics) gr.IsSelected = false;
                foreach (var gr in BackSideGraphics) gr.IsSelected = false;
                foreach (var vg in FrontSideVarGraphics) vg.IsSelected = false;
                foreach (var vg in BackSideVarGraphics) vg.IsSelected = false;
                foreach (var dt in FrontSideDates) dt.IsSelected = false;
                foreach (var dt in BackSideDates) dt.IsSelected = false;
                foreach (var sg in FrontSideSignatures) sg.IsSelected = false;
                foreach (var sg in BackSideSignatures) sg.IsSelected = false;
                foreach (var bc in FrontSideBarCodes) bc.IsSelected = false;
                foreach (var bc in BackSideBarCodes) bc.IsSelected = false;

                IsTextSelected = false;
                IsPhotoSelected = false;
                IsStaticGraphicSelected = false;
                IsVariableGraphicSelected = false;
                IsDateSelected = false;
                IsSignatureSelected = false;
                IsBarCodeSelected = false;

                if (itemType == "Photo")
                {
                    var newPhoto = new DesignPhotoElement { IsSelected = true };
                    IsPhotoSelected = true;
                    if (SelectedSide == "Front") FrontSidePhotos.Add(newPhoto);
                    else BackSidePhotos.Add(newPhoto);
                }
                else if (itemType == "Static Graphic")
                {
                    var newGraphic = new DesignGraphicElement { IsSelected = true };
                    IsStaticGraphicSelected = true;
                    if (SelectedSide == "Front") FrontSideGraphics.Add(newGraphic);
                    else BackSideGraphics.Add(newGraphic);
                }
                else if (itemType == "Variable Graphic")
                {
                    var newVarGraphic = new DesignVariableGraphicElement { IsSelected = true };
                    IsVariableGraphicSelected = true;
                    if (SelectedSide == "Front") FrontSideVarGraphics.Add(newVarGraphic);
                    else BackSideVarGraphics.Add(newVarGraphic);
                }
                else if (itemType == "Date")
                {
                    var newDate = new DesignDateElement { IsSelected = true };
                    IsDateSelected = true;
                    if (SelectedSide == "Front") FrontSideDates.Add(newDate);
                    else BackSideDates.Add(newDate);
                }
                else if (itemType == "Signature")
                {
                    var newSig = new DesignSignatureElement { IsSelected = true };
                    IsSignatureSelected = true;
                    if (SelectedSide == "Front") FrontSideSignatures.Add(newSig);
                    else BackSideSignatures.Add(newSig);
                }
                else if (itemType == "Bar Code")
                {
                    var newBarCode = new DesignBarCodeElement { IsSelected = true };
                    IsBarCodeSelected = true;
                    if (SelectedSide == "Front") FrontSideBarCodes.Add(newBarCode);
                    else BackSideBarCodes.Add(newBarCode);
                }
                else
                {
                    string defaultText = itemType.Contains("Static") ? "Static Text Field" : "Dynamic Text Field";
                    var newText = new DesignTextElement { Text = defaultText, IsSelected = true };
                    IsTextSelected = true;
                    if (SelectedSide == "Front") FrontSideElements.Add(newText);
                    else BackSideElements.Add(newText);
                }
            }
        }
    }
}
