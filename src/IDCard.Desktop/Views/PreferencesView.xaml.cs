using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace IDCard.Desktop.Views
{
    public partial class PreferencesView : UserControl
    {
        public PreferencesView()
        {
            InitializeComponent();
        }

        // Preferences ခလုတ်ကို နှိပ်သည့်အခါ
        private void PreferencesTab_Click(object sender, RoutedEventArgs e)
        {
            // Sidebar button များကို Active/Inactive အရောင်ပြောင်းလဲခြင်း
            PreferencesNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            PreferencesNavBtn.FontWeight = FontWeights.Bold;

            ChangePasswordNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            ChangePasswordNavBtn.FontWeight = FontWeights.SemiBold;

            // Preferences Form Content ကို ပြန်လည်ဖော်ပြခြင်း
            SettingsContentArea.Content = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = new StackPanel
                {
                    Margin = new Thickness(30),
                    Children =
                    {
                        new TextBlock { Text = "Manage Your Preferences", FontSize = 22, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E3A8A")), Margin = new Thickness(0, 0, 0, 15) },
                        
                        // Sub-tab indicator line
                        new Border 
                        { 
                            BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1D5DB")), 
                            BorderThickness = new Thickness(0, 0, 0, 1), 
                            Margin = new Thickness(0, 0, 0, 20),
                            Child = new StackPanel 
                            { 
                                Orientation = Orientation.Horizontal,
                                Children = 
                                {
                                    new Border
                                    {
                                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB")),
                                        BorderThickness = new Thickness(0, 0, 0, 2),
                                        Padding = new Thickness(10, 8),
                                        Child = new TextBlock { Text = "Preferences", FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB")) }
                                    }
                                }
                            }
                        },

                        new TextBlock { Text = "General Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 12) },
                        
                        // Checkbox 1
                        CreatePreferenceRow("Display tooltip for license expiration", false),
                        // Checkbox 2
                        CreatePreferenceRow("Always show Quick Start on sign in", false),
                        // Checkbox 3
                        CreatePreferenceRow("Display training tips for designing a credential", false),

                        new Separator { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E5E7EB")), Margin = new Thickness(0, 20, 0, 20) },

                        new TextBlock { Text = "Printer Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 12) },
                        CreatePrinterRow("Printer", new ComboBox { Height = 28 }),
                        CreatePrinterCheckboxRow("Always prompt for printer", true),
                        CreatePrinterRow("Hopper", new ComboBox { Height = 28 }),

                        new Separator { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E5E7EB")), Margin = new Thickness(0, 20, 0, 20) },

                        new TextBlock { Text = "Quick Start Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 12) },
                        CreatePrinterCheckboxRow("Always confirm exit from Quick Start", true),

                        new Separator { Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E5E7EB")), Margin = new Thickness(0, 20, 0, 20) },

                        new TextBlock { Text = "Report Preferences", FontSize = 14, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 12) },
                        CreateReportRow("Maximum number of records per report", "1000"),

                        // Save & Cancel Buttons
                        new StackPanel 
                        { 
                            Orientation = Orientation.Horizontal, 
                            Margin = new Thickness(0, 15, 0, 30),
                            Children = 
                            {
                                new Button { Content = "Save", Width = 90, Height = 32, Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB")), Foreground = Brushes.White, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 10, 0) },
                                new Button { Content = "Cancel", Width = 90, Height = 32, Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E5E7EB")), Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), FontWeight = FontWeights.Bold }
                            }
                        }
                    }
                }
            };
        }

        // Change Your Password ခလုတ်ကို နှိပ်သည့်အခါ
        private void ChangePasswordTab_Click(object sender, RoutedEventArgs e)
        {
            // Sidebar button များကို Active/Inactive အရောင်ပြောင်းလဲခြင်း
            ChangePasswordNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            ChangePasswordNavBtn.FontWeight = FontWeights.Bold;

            PreferencesNavBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Transparent"));
            ChangePasswordNavBtn.FontWeight = FontWeights.SemiBold;

            // Change Password Form Content
            var passwordStackPanel = new StackPanel { Margin = new Thickness(30) };
            passwordStackPanel.Children.Add(new TextBlock { Text = "Change Your Password", FontSize = 22, FontWeight = FontWeights.Bold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E3A8A")), Margin = new Thickness(0, 0, 0, 20) });

            passwordStackPanel.Children.Add(new TextBlock { Text = "Current Password", FontWeight = FontWeights.SemiBold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 5) });
            passwordStackPanel.Children.Add(new PasswordBox { Height = 32, VerticalContentAlignment = VerticalAlignment.Center, Margin = new Thickness(0, 0, 0, 15) });

            passwordStackPanel.Children.Add(new TextBlock { Text = "New Password", FontWeight = FontWeights.SemiBold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 5) });
            passwordStackPanel.Children.Add(new PasswordBox { Height = 32, VerticalContentAlignment = VerticalAlignment.Center, Margin = new Thickness(0, 0, 0, 15) });

            passwordStackPanel.Children.Add(new TextBlock { Text = "Confirm New Password", FontWeight = FontWeights.SemiBold, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#374151")), Margin = new Thickness(0, 0, 0, 5) });
            passwordStackPanel.Children.Add(new PasswordBox { Height = 32, VerticalContentAlignment = VerticalAlignment.Center, Margin = new Thickness(0, 0, 0, 20) });

            var saveBtn = new Button { Content = "Update Password", Width = 140, Height = 32, Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2563EB")), Foreground = Brushes.White, FontWeight = FontWeights.Bold };
            passwordStackPanel.Children.Add(saveBtn);

            SettingsContentArea.Content = new ScrollViewer
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Content = passwordStackPanel
            };
        }

        // Helper Methods for Dynamic UI generation
        private Grid CreatePreferenceRow(string text, bool isChecked)
        {
            var grid = new Grid { Margin = new Thickness(0, 0, 0, 10) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });

            var textBlock = new TextBlock { Text = text, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4B5563")) };
            var checkBox = new CheckBox { IsChecked = isChecked, HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Center };

            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(checkBox, 1);

            grid.Children.Add(textBlock);
            grid.Children.Add(checkBox);
            return grid;
        }

        private Grid CreatePrinterRow(string label, Control control)
        {
            var grid = new Grid { Margin = new Thickness(0, 0, 0, 10) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(220) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });

            var textBlock = new TextBlock { Text = label, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4B5563")) };

            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(control, 1);

            grid.Children.Add(textBlock);
            grid.Children.Add(control);
            return grid;
        }

        private Grid CreatePrinterCheckboxRow(string label, bool isChecked)
        {
            var grid = new Grid { Margin = new Thickness(0, 0, 0, 10) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(220) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });

            var textBlock = new TextBlock { Text = label, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4B5563")) };
            var checkBox = new CheckBox { IsChecked = isChecked, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Left };

            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(checkBox, 1);

            grid.Children.Add(textBlock);
            grid.Children.Add(checkBox);
            return grid;
        }

        private Grid CreateReportRow(string label, string defaultValue)
        {
            var grid = new Grid { Margin = new Thickness(0, 0, 0, 25) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(250) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });

            var textBlock = new TextBlock { Text = label, VerticalAlignment = VerticalAlignment.Center, Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4B5563")) };
            var textBox = new TextBox { Text = defaultValue, Height = 28, VerticalContentAlignment = VerticalAlignment.Center, Padding = new Thickness(5, 0, 5, 0) };

            Grid.SetColumn(textBlock, 0);
            Grid.SetColumn(textBox, 1);

            grid.Children.Add(textBlock);
            grid.Children.Add(textBox);
            return grid;
        }
    }
}
