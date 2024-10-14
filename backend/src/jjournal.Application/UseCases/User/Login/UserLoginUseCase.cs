using AutoMapper;
using jjournal.Application.Services.Security;
using jjournal.Application.UseCases.User.Login.Validator;
using jjournal.Application.UseCases.User.Register.Validator;
using jjournal.Communication.Requests.User;
using jjournal.Communication.Responses;
using jjournal.Domain.Interfaces.Repositories;
using jjournal.Exception.Base;

namespace jjournal.Application.UseCases.User.Login
{
    public class UserLoginUseCase : IUserLoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IUserLoginValidator _validator;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public UserLoginUseCase(IUserRepository userRepository, IUserLoginValidator validator, IMapper mapper, IPasswordHasher passwordHasher, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _uow = uow;
        }

        public async Task<UserLoginResponse> Execute(UserLoginRequest request)
        {
            await Validate(request);

            // VALIDO SE A SENHA ESTÁ CORRETA
            var user = await _userRepository.GetAsync(x => x.Email == request.Email, false);

            var verify = _passwordHasher.VerifyPassword(request.Password, user!.Password);

            if (!verify)
            {
                throw new InvalidLoginException();
            }

            // GERAR E DEVOLVER O TOKEN

            return new UserLoginResponse();
        }

        private async Task Validate(UserLoginRequest request)
        {
            var result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
