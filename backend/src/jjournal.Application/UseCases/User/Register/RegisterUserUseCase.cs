﻿using AutoMapper;
using jjournal.Application.Services.Security;
using jjournal.Application.UseCases.User.Register.Validator;
using jjournal.Communication.Requests.User;
using jjournal.Domain.Interfaces.Repositories;
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
        public RegisterUserUseCase(IUserRepository userRepository, IRegisterUserValidator validator, IMapper mapper, IPasswordHasher passwordHasher, IUnitOfWork uow)
        {
            _userRepository = userRepository;
            _validator = validator;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _uow = uow;
        }
        public async Task Execute(RegisterUserRequest request)
        {
            Validate(request);

            var entity = _mapper.Map<Domain.Models.Entities.User>(request);
            entity.Password = _passwordHasher.HashPassword(request.Password);

            await _userRepository.CreateAsync(entity);
            await _uow.Commit();
        }
        
        private void Validate(RegisterUserRequest request)
        {
            var result = _validator.Validate(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errors);
            }
        }
    }
}
