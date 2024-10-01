using jjournal.Application.UseCases.User.Register.Validator;
using jjournal.CommonTestUtilities.Requests;
using jjournal.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace jjournal.Validators.Tests.User.Register
{
    public class ValidatorTest
    {
        
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly RegisterUserValidator _validator;

        public ValidatorTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _validator = new RegisterUserValidator(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Success()
        {
            var user = RegisterUserRequestBuilder.Build();

            _userRepositoryMock.Setup(repo => repo.UserExists(It.IsAny<string>())).ReturnsAsync(false);

            var result =  await _validator.ValidateAsync(user);

            Assert.True(result.IsValid);
        }
    }
}
