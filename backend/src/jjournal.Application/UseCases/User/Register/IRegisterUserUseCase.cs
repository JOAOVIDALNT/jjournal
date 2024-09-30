using jjournal.Communication.Requests.User;

namespace jjournal.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        Task Execute(RegisterUserRequest request);
    }
}
