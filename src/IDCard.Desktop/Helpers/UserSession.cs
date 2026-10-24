using IDCard.Desktop.Models;

namespace IDCard.Desktop.Helpers
{
    public static class UserSession
    {
        private static User? _currentUser;

        public static User? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                // လိုအပ်ပါက Session ပြောင်းလဲမှုကို Event ဖြင့် အကြောင်းကြားနိုင်သည်
            }
        }

        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsAdmin => CurrentUser?.Role == "Admin";

        // Logout ပြုလုပ်သည့်အခါ Session ကို ရှင်းလင်းရန်
        public static void ClearSession()
        {
            CurrentUser = null;
        }
    }
}
