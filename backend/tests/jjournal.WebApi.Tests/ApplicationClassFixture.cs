using System.Net.Http.Json;

namespace jjournal.WebApi.Tests
{
    public class ApplicationClassFixture : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        public ApplicationClassFixture(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();

        protected async Task<HttpResponseMessage> Post(string method, object request, string culture = "en")
        {
            ChangeRequestedCulture(culture);
            return await _httpClient.PostAsJsonAsync(method, request);
        }

        private void ChangeRequestedCulture(string culture)
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
                _httpClient.DefaultRequestHeaders.Remove("Accept-Language");

            _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);
        }
    }
}
