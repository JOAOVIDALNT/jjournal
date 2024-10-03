using jjournal.Application.UseCases.User.Register;
using jjournal.CommonTestUtilities.Repositories;
using jjournal.CommonTestUtilities.Requests;
using jjournal.CommonTestUtilities.Services;
using jjournal.CommonTestUtilities.Validators;

namespace jjournal.UseCases.Tests.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = RegisterUserRequestBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.Execute(user);
            
            Assert.NotNull(result);
            Assert.Equal(result.Name, user.Name);
        }

        private static RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var userRepository = new UserRepositoryBuilder();
            var mapper = MapperBuilder.Build();
            var hasher = PasswordHasherBuilder.Build();
            var uow = UnitOfWorkBuilder.Build();
            var validator = new RegisterUserValidatorBuilder();

            if (!string.IsNullOrEmpty(email))
                userRepository.UserExists(email);

            return new RegisterUserUseCase(userRepository.Build(), validator.Build(userRepository.Build()), mapper, hasher, uow);
        }
    }
}
