using BCrypt.Net;
using Org.BouncyCastle.Crypto.Generators;


namespace RealEstate.Core.Services.Helpers
{
    // PasswordHasher.cs
    
    public static class PasswordHasher
    {
        // Hash a password
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }

        // Verify a password against its hash
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
