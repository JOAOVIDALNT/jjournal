﻿using FluentValidation;
using jjournal.Communication.Requests.User;
using jjournal.Domain.Interfaces.Repositories;
using jjournal.Exception;
using jjournal.Exception.Base;

namespace jjournal.Application.UseCases.User.Register.Validator
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>, IRegisterUserValidator
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ResourceMessageException.NAME_EMPTY);


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ResourceMessageException.EMAIL_EMPTY);

            RuleFor(x => x.Password.Length)
                .GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.PASSWORD_INVALID);

            When(x => !string.IsNullOrEmpty(x.Email), () =>
            {
                RuleFor(x => x.Email)
                .EmailAddress()
                    .WithMessage(ResourceMessageException.EMAIL_INVALID)
                .MustAsync(async (email, cancellation) => !await _userRepository.UserExists(email))
                    .WithMessage(ResourceMessageException.EMAIL_EXISTS);
            });

            When(x => !string.IsNullOrEmpty(x.Name), () =>
            {
                RuleFor(x => x.Name).Length(3, 30).WithMessage(ResourceMessageException.NAME_LENGTH);
            });
        }

        /* MÉTODO CUSTOM PARA APOIAR OS TESTES DE VALIDAÇÃO QUE NÃO PASSAM PELO RETORNO ESPERADO TRATADO */
        public async Task ValidateAndThrowCustomAsync(RegisterUserRequest request)
        {
            var result = await ValidateAsync(request);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
