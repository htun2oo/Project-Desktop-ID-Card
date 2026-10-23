using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace IDCard.Desktop.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // ဝင်းဒိုးပိတ်သည့်အခါ Background Process များကိုပါ တစ်ပါတည်း ပိတ်ရန် Event ချိတ်ဆက်ခြင်း
            this.Closing += MainWindow_Closing;
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.ContextMenu != null)
            {
                btn.ContextMenu.PlacementTarget = btn;
                btn.ContextMenu.Placement = PlacementMode.Bottom;
                btn.ContextMenu.IsOpen = true;
            }
        }

        // Sign Out လုပ်သည့်အခါ Login ဝင်းဒိုးကိုဖွင့်ပြီး ကျန်ရှိနေသော Background Processes များကို ပိတ်ခြင်း
        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            
            // လက်ရှိ MainWindow ကို ပိတ်ခြင်း (Closing Event မှတစ်ဆင့် Background Processes များကို ရှင်းလင်းပေးမည်)
            this.Close();
        }

        // ဝင်းဒိုးပိတ်သွားသည့်အခါ Background တွင် Run နေသော App သက်ဆိုင်ရာ Process များကို အပြီးတိုင် ပိတ်ခြင်း
        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                // လက်ရှိ Application ၏ Process အမည်ကို ရယူပြီး ရှင်းလင်းခြင်း
                var currentProcess = Process.GetCurrentProcess();
                
                // အကယ်၍ အခြား dotnet background processes များ ကျန်ရှိနေပါက အပြည့်အစုံ ပိတ်ရန် (Application.Current.Shutdown() ကို အသုံးပြုသည်)
                Application.Current.Shutdown();
            }
            catch (Exception)
            {
                // ဖြစ်ပေါ်လာနိုင်သော Error များကို ကျော်လွန်ရန်
            }
        }

        private void Preferences_Click(object sender, RoutedEventArgs e)
        {
            var preferencesView = new PreferencesView();

            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(preferencesView, 2);
            MainContentArea.Children.Add(preferencesView);
        }

        private void CredentialsButton_Click(object sender, RoutedEventArgs e)
        {
            CredentialsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            CredentialsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B21A8"));

            ReportsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#581C87"));
            ReportsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

            var mainWindowInstance = new MainWindow();
            this.Content = mainWindowInstance.Content;
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ReportsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
            ReportsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6B21A8"));

            CredentialsTabBtn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#581C87"));
            CredentialsTabBtn.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

            var reportsView = new ReportsView();

            MainContentArea.Children.Clear();
            Grid.SetColumnSpan(reportsView, 2);
            MainContentArea.Children.Add(reportsView);
        }
    }
}
