using jjournal.CommonTestUtilities.Requests;
using System.Net;

namespace jjournal.WebApi.Tests.User.Register
{
    public class RegisterUserTest(CustomWebApplicationFactory factory) : ApplicationClassFixture(factory)
    {
        private readonly string method = "User";

        [Fact]
        public async Task Success()
        {
            var request = RegisterUserRequestBuilder.Build();

            var response = await Post(method, request);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
