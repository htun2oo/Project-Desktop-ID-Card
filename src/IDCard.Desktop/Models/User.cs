using System.ComponentModel.DataAnnotations;

namespace IDCard.Desktop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // သို့မဟုတ် UserId

        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
