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
            // ဤနေရာတွင် User ID နှင့် Password ထည့်သွင်းမှုကို စစ်ဆေးနိုင်ပါသည်
            // ဥပမာအားဖြင့် အချက်အလက်မှန်ကန်သည်ဟု ယူဆ၍ Sign In ပြုလုပ်ပါမည်

            // 1. Login Successful မက်ဆေ့ဂျ်ပြသခြင်း
            MessageBox.Show("Login Successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            // 2. App.xaml.cs သို့ Login အောင်မြင်ကြောင်း အချက်ပြရန် DialogResult ကို true ပေးခြင်း
            this.DialogResult = true;

            // 3. Login Window ကို ပိတ်ခြင်း (MainWindow ဆက်ပွင့်လာမည်)
            this.Close();
        }
    }
}
