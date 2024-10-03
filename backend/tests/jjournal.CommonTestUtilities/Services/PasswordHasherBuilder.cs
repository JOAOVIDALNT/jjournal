using jjournal.Application.Services.Security;

namespace jjournal.CommonTestUtilities.Services
{
    public class PasswordHasherBuilder
    {
        public static PasswordHasher Build() => new();
    }
}
