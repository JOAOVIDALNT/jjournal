using FluentValidation;
using jjournal.Communication.Requests.User;
using jjournal.Domain.Interfaces.Repositories;
using jjournal.Exception;

namespace jjournal.Application.UseCases.User.Register.Validator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY)
                .Length(3, 30).WithMessage(ResourceMessageException.NAME_LENGTH);


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY)
                .Length(10, 255).WithMessage(ResourceMessageException.EMAIL_INVALID);

            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.PASSWORD_INVALID);

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                .EmailAddress().WithMessage(ResourceMessageException.EMAIL_INVALID)
                .MustAsync(async (email, cancellation) => !await _userRepository.UserExists(email))
                    .WithMessage(ResourceMessageException.EMAIL_EXISTS);
            });

        }
    }
}
