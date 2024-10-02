using jjournal.Application.UseCases.User.Register.Validator;
using jjournal.CommonTestUtilities.Repositories;
using jjournal.CommonTestUtilities.Requests;
using jjournal.Exception;
using jjournal.Exception.Base;

namespace jjournal.Validators.Tests.User.Register
{
    public class ValidatorTest
    {
        [Fact]
        public async Task Success()
        {
            var user = RegisterUserRequestBuilder.Build();

            var validator = CreateMock();

            var result =  await validator.ValidateAsync(user);

            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task Error_Email_Exists()
        {
            var user = RegisterUserRequestBuilder.Build();

            var validator = CreateMock(user.Email);

            var action = async () => await validator.ValidateAndThrowCustomAsync(user);

            var exception = await Assert.ThrowsAsync<ErrorOnValidationException>(action);

            Assert.Single(exception.ErrorMessages.ToList());
            Assert.Equal(ResourceMessageException.EMAIL_EXISTS, exception.ErrorMessages.First());
        }

        [Fact]
        public async Task Error_Email_Empty()
        {
            var user = RegisterUserRequestBuilder.Build();
            user.Email = string.Empty;

            var validator = CreateMock();

            var result = await validator.ValidateAsync(user);

            var errors = result.Errors.Select(e => e.ErrorMessage);

            Assert.False(result.IsValid);
            Assert.Single(errors);
            Assert.Equal(ResourceMessageException.EMAIL_EMPTY, errors.First());
        }

        [Fact]
        public async Task Error_Email_Invalid()
        {
            var user = RegisterUserRequestBuilder.Build();
            user.Email = "x";

            var validator = CreateMock();

            var result = await validator.ValidateAsync(user);

            var errors = result.Errors.Select(e => e.ErrorMessage);

            Assert.False(result.IsValid);
            Assert.Single(errors);
            Assert.Equal(ResourceMessageException.EMAIL_INVALID, errors.First());
        }

        [Fact]
        public async Task Error_Name_Empty()
        {
            var user = RegisterUserRequestBuilder.Build();
            user.Name = string.Empty;

            var validator = CreateMock();

            var result = await validator.ValidateAsync(user);

            var errors = result.Errors.Select(e => e.ErrorMessage);

            Assert.False(result.IsValid);
            Assert.Single(errors);
            Assert.Equal(ResourceMessageException.NAME_EMPTY, errors.First());
        }

        [Fact]
        public async Task Error_Name_Length()
        {
            var user = RegisterUserRequestBuilder.Build();
            user.Name = "ju";

            var validator = CreateMock();

            var result = await validator.ValidateAsync(user);

            var errors = result.Errors.Select(e => e.ErrorMessage);

            Assert.False(result.IsValid);
            Assert.Single(errors);
            Assert.Equal(ResourceMessageException.NAME_LENGTH, errors.First());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public async Task Error_Password_Invalid(int passwordLength)
        {
            var user = RegisterUserRequestBuilder.Build(passwordLength);
            
            var validator = CreateMock();

            var result = await validator.ValidateAsync(user);

            var errors = result.Errors.Select(e => e.ErrorMessage);

            Assert.False(result.IsValid);
            Assert.Single(errors);
            Assert.Equal(ResourceMessageException.PASSWORD_INVALID, errors.First());
        }
        private static RegisterUserValidator CreateMock(string? email = null) // ESTÁTICO POIS NÃO ACESSA DADOS DA INSTÂNCIA (INDEPENDENTE)
        {
            var userRepository = new UserRepositoryBuilder();

            if (!string.IsNullOrEmpty(email))
                userRepository.UserExists(email);

            return new RegisterUserValidator(userRepository.Build());
        }
    }
}
