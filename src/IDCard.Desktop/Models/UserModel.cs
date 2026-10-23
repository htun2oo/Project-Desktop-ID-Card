namespace IDCard.Desktop.Models
{
    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Production တွင် Hashing သုံးသင့်ပါသည်
        public string Role { get; set; } = "User"; // "Admin" သို့မဟုတ် "User"
    }
}
