using jjournal.Domain.Models.Entities;

namespace jjournal.Application.Services.Security
{
    public interface ITokenGenerator
    {
        string GenerateToken(User user);
    }
}
