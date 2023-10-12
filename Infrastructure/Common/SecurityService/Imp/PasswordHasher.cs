using BCryptNet = BCrypt.Net.BCrypt;

namespace Infrastructure.Common.SecurityService.Imp
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int WorkFactor = 12;
        public string HashPassword(string password)
        {
            string salt = BCryptNet.GenerateSalt(WorkFactor);
            string hashedPassword = BCryptNet.HashPassword(password, salt);
            return hashedPassword;
        }

        public bool VerifyPasswordB(string password, string hashedPassword)
        {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}
