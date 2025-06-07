using System.Text.RegularExpressions;

namespace UserApi.Utils
{
    public static class RegexValidator
    {
        public static bool IsValidEmail(string email) 
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public static bool IsValidPassword(string password, string pattern) 
        {
            return Regex.IsMatch(password, pattern);
        }

    }
}
