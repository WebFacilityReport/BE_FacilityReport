namespace Infrastructure.Common.SecurityService
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPasswordB(string password, string hashedPassword);
    }
}
