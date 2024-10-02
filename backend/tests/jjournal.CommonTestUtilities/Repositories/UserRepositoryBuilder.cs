using jjournal.Domain.Interfaces.Repositories;
using Moq;

namespace jjournal.CommonTestUtilities.Repositories
{
    public class UserRepositoryBuilder
    {
        private readonly Mock<IUserRepository> _userRepository;

        public UserRepositoryBuilder() => _userRepository = new Mock<IUserRepository>();

        public void UserExists(string email)
        {
            /* O PADRÃO É O FLUXO ASSUMIR O VALOR FALSO NA INSTÂNCIA DO MOCK, AO DETERMINAR O MÉTODO MUDAMOS O RETORNO 
               OU SEJA, ESSE CASO DEVE SER UTILIZADO EM CASOS DE TESTES DE FALHA PARA USUÁRIO JÁ REGISTRADO.             
            */
            _userRepository.Setup(repo => repo.UserExists(email)).ReturnsAsync(true);
        }

        public IUserRepository Build() => _userRepository.Object;
    }
}
