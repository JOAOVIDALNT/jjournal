using jjournal.Communication.Requests.User;
using jjournal.Communication.Responses;

namespace jjournal.Application.UseCases.User.Register
{
    public interface IRegisterUserUseCase
    {
        Task<RegisterUserResponse> Execute(RegisterUserRequest request);
    }
}
