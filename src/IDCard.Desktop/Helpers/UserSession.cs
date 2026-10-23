using IDCard.Desktop.Models; // Model ကို အသုံးပြုရန် မဖြစ်မနေ ထည့်ရန်

namespace IDCard.Desktop.Helpers
{
    public static class UserSession
    {
        public static User? CurrentUser { get; set; }

        public static bool IsAdmin => CurrentUser?.Role == "Admin";
    }
}
