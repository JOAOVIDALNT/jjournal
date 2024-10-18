using jjournal.Application.UseCases.User.Register;
using jjournal.CommonTestUtilities.Repositories;
using jjournal.CommonTestUtilities.Requests;
using jjournal.CommonTestUtilities.Services;
using jjournal.CommonTestUtilities.Validators;
using jjournal.Domain.Interfaces.Repositories;
using jjournal.Domain.Models.Entities;
using jjournal.Exception;
using jjournal.Exception.Base;
using Moq;

namespace jjournal.UseCases.Tests.User.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = RegisterUserRequestBuilder.Build();

            // INSTÂNCIAS DE MOCKS PARA TESTES SOBRE AÇÕES
            var uowMock = new Mock<IUnitOfWork>(); 
            var repoMock = new Mock<IUserRepository>();

            var useCase = CreateMockUseCase(uowMock.Object, repoMock.Object);

            var result = await useCase.Execute(user);
            
            Assert.NotNull(result);
            Assert.Equal(result.Name, user.Name);
            repoMock.Verify(repo => repo.CreateAsync(It.IsAny<Domain.Models.Entities.User>()), Times.Once);
            uowMock.Verify(uow => uow.Commit(), Times.Once);
        }

        [Fact]
        public async Task Error_User_Exists()
        {
            var user = RegisterUserRequestBuilder.Build();

            var uowMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IUserRepository>();

            repoMock.Setup(repo => repo.UserExists(user.Email)).ReturnsAsync(true);

            var useCase = CreateMockUseCase(uowMock.Object, repoMock.Object);

            var act = async () => await useCase.Execute(user);

            var exception = await Assert.ThrowsAsync<ErrorOnValidationException>(act);

            Assert.Single(exception.ErrorMessages);
            Assert.Equal(ResourceMessageException.EMAIL_EXISTS, exception.ErrorMessages.First());
            repoMock.Verify(repo => repo.CreateAsync(It.IsAny<Domain.Models.Entities.User>()), Times.Never);
            uowMock.Verify(uow => uow.Commit(), Times.Never);
        }

        private static RegisterUserUseCase CreateMockUseCase(IUnitOfWork uow, IUserRepository repo, string? email = null)
        {
            var mapper = MapperBuilder.Build();
            var hasher = PasswordHasherBuilder.Build();
            var validator = new RegisterUserValidatorBuilder();
            var roleMock = new Mock<IRoleRepository>();
            var userRoleMock = new Mock<IUserRoleRepository>();

            return new RegisterUserUseCase(repo, validator.Build(repo), mapper, hasher, uow, roleMock.Object, userRoleMock.Object);
        }
    }
}
