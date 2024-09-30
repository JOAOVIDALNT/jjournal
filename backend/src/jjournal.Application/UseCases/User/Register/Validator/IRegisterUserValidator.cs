using FluentValidation;
using jjournal.Communication.Requests.User;

namespace jjournal.Application.UseCases.User.Register.Validator
{
    public interface IRegisterUserValidator : IValidator<RegisterUserRequest>
    {
    }
}
