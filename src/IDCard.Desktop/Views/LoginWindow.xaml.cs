using System.Windows;

namespace IDCard.Desktop.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            // Login အောင်မြင်ကြောင်း မက်ဆေ့ဂျ်ပြသခြင်း
            MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // App.xaml.cs သို့ Login အောင်မြင်ကြောင်း အချက်ပြရန် DialogResult ကို true ပေးခြင်း
            this.DialogResult = true;

            // Login Window ကို ပိတ်ခြင်း (MainWindow ဆက်ပွင့်လာမည်)
            this.Close();
        }

        // Forgot Password အတွက် Event Handler ထည့်သွင်းခြင်း
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Password recovery feature will be available soon.", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
