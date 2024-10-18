using AutoMapper;
using jjournal.Application.Services.Security;
using jjournal.Application.UseCases.User.Register.Validator;
using jjournal.Communication.Requests.User;
using jjournal.Communication.Responses;
using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;
using jjournal.Exception.Base;

namespace jjournal.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IRegisterUserValidator _validator;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        public RegisterUserUseCase(IUserRepository userRepository, IRegisterUserValidator validator, IMapper mapper, IPasswordHasher passwordHasher, IUnitOfWork uow, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _uow = uow;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;

        }
        public async Task<RegisterUserResponse> Execute(RegisterUserRequest request)
        {
            await Validate(request);

            var entity = _mapper.Map<Domain.Models.Entities.User>(request);
            entity.Password = _passwordHasher.HashPassword(request.Password);

            var result = await _userRepository.CreateAsync(entity);

            
            if (!_roleRepository.RoleExistsAsync("user").GetAwaiter().GetResult())
            {
                await _roleRepository.CreateAsync(new Role { Name= "user" });
                await _uow.Commit();
            }
            var role = await _roleRepository.GetAsync(x => x.Name == "user");

            await _userRoleRepository.AddRoleToUser(result.Entity, role!);

            await _uow.Commit();

            return new RegisterUserResponse
            {
                Name = request.Name,
            };
        }

        private async Task Validate(RegisterUserRequest request)
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
