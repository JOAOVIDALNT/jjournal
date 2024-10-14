using jjournal.Communication.Requests.User;
using jjournal.Communication.Responses;

namespace jjournal.Application.UseCases.User.Login
{
    public interface IUserLoginUseCase
    {
        Task<UserLoginResponse> Execute(UserLoginRequest request);  
    }
}
