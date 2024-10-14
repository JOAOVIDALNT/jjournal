using jjournal.CommonTestUtilities.InlineData;
using jjournal.CommonTestUtilities.Requests;
using jjournal.Exception;
using System.Globalization;
using System.Net;
using System.Text.Json;

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

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Name_Empty(string culture)
        {
            var request = RegisterUserRequestBuilder.Build();
            request.Name = string.Empty;

            var response = await Post(method, request, culture);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            var errors = responseData.RootElement.GetProperty("errorMessages").EnumerateArray();

            var expectedMessage = ResourceMessageException.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));

            Assert.Single(errors);
            Assert.Contains(expectedMessage!, errors.First().ToString());
        }
    }
}
