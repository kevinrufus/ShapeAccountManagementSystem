using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace ShapeAccountManagemenSystem.Application.Helpers
{
    internal static class PasswordHashHelper
    {
        public static byte[] CreateSalt()
        {
            byte[] buffer = new byte[16];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(buffer);
            return buffer;
        }
        public static async Task<byte[]> Hash(string password, byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(password) || salt == null || salt == Array.Empty<byte>())
                return Array.Empty<byte>();

            var argon2 = new Argon2id(Encoding.Default.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };
            return await argon2.GetBytesAsync(16);
        }
        public static async Task<bool> VerifyPassword(string? password, string? salt, string? hash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(salt) || string.IsNullOrWhiteSpace(hash))
                return false;

            byte[] byteSalt = Convert.FromBase64String(salt);
            byte[] byteHash = Convert.FromBase64String(hash);
            byte[] newHash = await Hash(password, byteSalt);
            return byteHash.SequenceEqual(newHash);
        }
    }
}
