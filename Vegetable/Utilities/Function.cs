using System.Security.Cryptography;
using System.Text;

namespace Vegetable.Utilities
{
    public class Function
    {
        public static int _UserId = 0;
        public static string _Username = string.Empty;
        public static string _Email = string.Empty;
        public static string _Message = string.Empty;
        public static string _MessageEmail = string.Empty;
        public static bool _Role = false;

        // Tạo alias slug từ title
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }

        // Hàm SHA-256
        public static string SHA256Hash(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    strBuilder.Append(hashBytes[i].ToString("x2"));
                }
                return strBuilder.ToString();
            }
        }

        // Hàm hash mật khẩu SHA-256
        public static string SHA256Password(string? text)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;

            string str = SHA256Hash(text);
            for (int i = 0; i < 5; i++) // Chạy 5 vòng lặp
            {
                str = SHA256Hash(str + "_" + str);
            }
            return str;
        }

        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._Username) || string.IsNullOrEmpty(Function._Email) || (Function._UserId <= 0))
                return false;
            return true;
        }
        public static void Login(int userId, string username, string email)
        {
            _UserId = userId;
            _Username = username;
            _Email = email;
        }
        public static void Logout()
        {
            _UserId = 0;
            _Username = string.Empty;
            _Email = string.Empty;
        }
    }
}
