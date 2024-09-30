namespace jjournal.Application.Services.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string givenPassword, string storedPassword);
    }
}
