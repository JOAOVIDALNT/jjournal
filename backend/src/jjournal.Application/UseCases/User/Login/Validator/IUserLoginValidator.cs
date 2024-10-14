using FluentValidation;
using jjournal.Communication.Requests.User;

namespace jjournal.Application.UseCases.User.Login.Validator
{
    public interface IUserLoginValidator : IValidator<UserLoginRequest>
    {
    }
}
