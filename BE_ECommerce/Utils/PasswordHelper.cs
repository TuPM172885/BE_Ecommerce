using static BCrypt.Net.BCrypt;

namespace BE_ECommerce.Utils
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            return HashPassword(password); // OK
        }

        public static bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            return Verify(inputPassword, hashedPassword); // OK
        }
    }
}
