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

        private bool _isTextSelected;
        public bool IsTextSelected
        {
            get => _isTextSelected;
            set
            {
                if (_isTextSelected != value)
                {
                    _isTextSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<DesignTextElement> FrontSideElements { get; } = new ObservableCollection<DesignTextElement>();
        public ObservableCollection<DesignTextElement> BackSideElements { get; } = new ObservableCollection<DesignTextElement>();

        public ICommand CreateNewCredentialCommand { get; }
        public ICommand CloseCredentialCommand { get; }
        public ICommand OpenEditPropertiesCommand { get; }
        public ICommand CloseEditPropertiesCommand { get; }
        public ICommand SelectFrontSideCommand { get; }
        public ICommand SelectBackSideCommand { get; }
        public ICommand ShowPropertiesTabCommand { get; }
        public ICommand ShowLayersTabCommand { get; }
        public ICommand DropTextCommand { get; }

        public CredentialDesignsViewModel(Action enterEditor, Action exitEditor)
        {
            _enterEditor = enterEditor;
            _exitEditor = exitEditor;
            _isEditingCredential = false;
            _isEditPropertiesOpen = false;
            _selectedSide = "Front";
            _isLayersTabSelected = false;
            _isTextSelected = false;

            CreateNewCredentialCommand = new RelayCommand(_ => ExecuteCreateNewCredential());
            CloseCredentialCommand = new RelayCommand(_ => ExecuteCloseCredential());
            OpenEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = true);
            CloseEditPropertiesCommand = new RelayCommand(_ => IsEditPropertiesOpen = false);
            SelectFrontSideCommand = new RelayCommand(_ => SelectedSide = "Front");
            SelectBackSideCommand = new RelayCommand(_ => SelectedSide = "Back");
            ShowPropertiesTabCommand = new RelayCommand(_ => IsLayersTabSelected = false);
            ShowLayersTabCommand = new RelayCommand(_ => IsLayersTabSelected = true);
            DropTextCommand = new RelayCommand(parameter => ExecuteDropText(parameter));
        }

        public void ResetToListView()
        {
            _isEditingCredential = false;
            _isEditPropertiesOpen = false;
            _selectedSide = "Front";
            _isLayersTabSelected = false;
            _isTextSelected = false;
            FrontSideElements.Clear();
            BackSideElements.Clear();
            OnPropertyChanged(nameof(IsEditingCredential));
            OnPropertyChanged(nameof(IsEditPropertiesOpen));
            OnPropertyChanged(nameof(SelectedSide));
            OnPropertyChanged(nameof(IsLayersTabSelected));
            OnPropertyChanged(nameof(IsTextSelected));
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

        private void ExecuteDropText(object? parameter)
        {
            if (parameter is string textType)
            {
                foreach (var el in FrontSideElements) el.IsSelected = false;
                foreach (var el in BackSideElements) el.IsSelected = false;

                // ToolTip ပေါ်မူတည်၍ Dynamic သို့မဟုတ် Static text ကို ခွဲခြားသတ်မှတ်ခြင်း
                string defaultText = textType.Contains("Dynamic") ? "Dynamic Text Field" : "Static Text Field";

                var newElement = new DesignTextElement
                {
                    Text = defaultText,
                    IsSelected = true
                };

                IsTextSelected = true;

                if (SelectedSide == "Front")
                {
                    FrontSideElements.Add(newElement);
                }
                else
                {
                    BackSideElements.Add(newElement);
                }
            }
        }
    }
}
