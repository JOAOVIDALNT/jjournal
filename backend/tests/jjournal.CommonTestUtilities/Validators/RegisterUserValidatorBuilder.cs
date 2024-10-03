using jjournal.Application.UseCases.User.Register.Validator;
using jjournal.Domain.Interfaces.Repositories;

namespace jjournal.CommonTestUtilities.Validators
{
    public class RegisterUserValidatorBuilder
    {
        public RegisterUserValidator Build(IUserRepository repo) => new(repo);
    }
}
