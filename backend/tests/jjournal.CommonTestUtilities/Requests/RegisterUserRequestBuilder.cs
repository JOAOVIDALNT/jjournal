using Bogus;
using jjournal.Communication.Requests.User;

namespace jjournal.CommonTestUtilities.Requests
{
    public class RegisterUserRequestBuilder
    {
        public static RegisterUserRequest Build(int passwordLength = 10)
        {
            return new Faker<RegisterUserRequest>()
                .RuleFor(user => user.Name, (f) => f.Person.FirstName)
                .RuleFor(user => user.Email, (f, u) => f.Internet.Email(u.Name))
                .RuleFor(user => user.Password, (f) => f.Internet.Password(passwordLength));
        }
    }
}
