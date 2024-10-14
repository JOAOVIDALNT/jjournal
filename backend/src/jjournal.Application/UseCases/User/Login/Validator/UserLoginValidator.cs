using FluentValidation;
using jjournal.Communication.Requests.User;
using jjournal.Domain.Interfaces.Repositories;
using jjournal.Exception;

namespace jjournal.Application.UseCases.User.Login.Validator
{
    public class UserLoginValidator : AbstractValidator<UserLoginRequest>, IUserLoginValidator
    {
        private readonly IUserRepository _userRepository;
        public UserLoginValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY);
            
            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.LOGIN_INVALID);

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage(ResourceMessageException.LOGIN_INVALID)
                .MustAsync(async (email, cancellation) => await _userRepository.UserExists(email))
                    .WithMessage(ResourceMessageException.LOGIN_INVALID);
            });

        }
    }
}
