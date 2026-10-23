using IDCard.Desktop.Models;

namespace IDCard.Desktop.Helpers
{
    public static class UserSession
    {
        public static User? CurrentUser { get; set; }

        public static bool IsAdmin => CurrentUser?.Role == "Admin";
    }
}
