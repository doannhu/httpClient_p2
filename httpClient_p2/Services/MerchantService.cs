using httpClient_p2.Models;
using httpClient_p2.Ultis;

namespace httpClient_p2.Services
{
    public class MerchantService: IRunAsyncService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptionsWrapper _jsonSerializerOptionsWrapper;

        public MerchantService(IHttpClientFactory httpClientFactory, JsonSerializerOptionsWrapper jsonSerializerOptionsWrapper)
        {
            _httpClientFactory = httpClientFactory;
            _jsonSerializerOptionsWrapper = jsonSerializerOptionsWrapper;
        }

        public async Task RunAsync()
        {
            await GetMerchantsAsync(CancellationToken.None);
        }

        public async Task<IEnumerable<Merchant>?> GetMerchantsAsync(CancellationToken cancellationToken)
        {
            var method = HttpMethod.Get;

            string url = "https://localhost:7047/merchants/v1";

            var httpRequestMessage = new HttpRequestMessage(method, url);

            var httpClient = _httpClientFactory.CreateClient("GetMerchants");

            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage, cancellationToken);

            httpResponseMessage.EnsureSuccessStatusCode();

            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var merchants = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Merchant>>(contentStream, _jsonSerializerOptionsWrapper.Options);

            return merchants;
        }
    }
}
