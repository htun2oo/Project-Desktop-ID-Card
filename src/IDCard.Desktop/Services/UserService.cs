using System;
using System.Linq;
using IDCard.Desktop.Models;

namespace IDCard.Desktop.Services
{
    public static class UserService
    {
        public static User? Authenticate(string username, string password)
        {
            try
            {
                using var context = new AppDbContext();
                return context.Users.FirstOrDefault(u => 
                    u.Username.ToLower() == username.ToLower() && u.Password == password);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Auth Error: {ex.Message}");
                return null;
            }
        }

        public static bool RegisterUser(string username, string password, string role = "User")
        {
            try
            {
                using var context = new AppDbContext();
                if (context.Users.Any(u => u.Username.ToLower() == username.ToLower()))
                {
                    return false; // User ရှိပြီးသားဖြစ်ပါက
                }

                context.Users.Add(new User
                {
                    Username = username,
                    Password = password,
                    Role = role
                });
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Register Error: {ex.Message}");
                return false;
            }
        }
    }
}
