using System.Net.Http;
using System.Threading.Tasks;
using AppRetry.API.Entities;
using AppRetry.API.Interfce.IServices;
using Newtonsoft.Json;

namespace AppRetry.API.Services
{
    public class CatalogService : ICatalogService
    {
        // https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        // https://medium.com/cheranga/calling-web-apis-using-typed-httpclients-net-core-20d3d5ce980#id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6IjhhNjNmZTcxZTUzMDY3NTI0Y2JiYzZhM2E1ODQ2M2IzODY0YzA3ODciLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJuYmYiOjE1NzIyNDE0MjEsImF1ZCI6IjIxNjI5NjAzNTgzNC1rMWs2cWUwNjBzMnRwMmEyamFtNGxqZGNtczAwc3R0Zy5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsInN1YiI6IjExMTMxNjU5MDYxMTc4NjUxODcxNSIsImVtYWlsIjoibmVsc29udGVjdGlAZ21haWwuY29tIiwiZW1haWxfdmVyaWZpZWQiOnRydWUsImF6cCI6IjIxNjI5NjAzNTgzNC1rMWs2cWUwNjBzMnRwMmEyamFtNGxqZGNtczAwc3R0Zy5hcHBzLmdvb2dsZXVzZXJjb250ZW50LmNvbSIsIm5hbWUiOiJOZWxzb24gTWFydGlucyIsInBpY3R1cmUiOiJodHRwczovL2xoMy5nb29nbGV1c2VyY29udGVudC5jb20vYS0vQUF1RTdtRG9UZTVjYkVWcFM0MExlaFgzb2tKcGZuSjFPSGVLREIxeFBteHk0UT1zOTYtYyIsImdpdmVuX25hbWUiOiJOZWxzb24iLCJmYW1pbHlfbmFtZSI6Ik1hcnRpbnMiLCJpYXQiOjE1NzIyNDE3MjEsImV4cCI6MTU3MjI0NTMyMSwianRpIjoiNThlNmJlYTY5ODFhNzE1OThkZTRmMGFjZDJjYzdjYTYxYjI5OWRhYSJ9.bzWilc0lVLRPvKIVx2h6LdBtIIMN0walrPdpVhx3iK9gz9sEpevksjSNaLsziaPmzMDZTnnARbZvdQ1X-WDUP98uYbGSUgBc689flA4XqUn89IGuO9AJB-MacIlW14k6aZ5uXpwcFiHeY22EnrQ_wvod2AhgsGZFoXrP4yOmqrEWNEF4E0Se_K3d7vnUaXhOQuRhXigtWKlqE89WYE2h6Y17huX4wF7vxBWPTPJWMqbcMfGXtK_PBlheaX5dLTFlloID6ryOzNgnGqixoUFHWiNhP7pCbeF5JUQrh3qbQfQjC8ioEoIxd0XcpVlRY1dcGbD9mGaLz8W5hxy3WH3Sbg
        // https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        // https://api.github.com/repos/aspnet/AspNetCore.Docs/branches
        // https://medium.com/@renato.groffe/asp-net-core-boas-pr%C3%A1ticas-na-implementa%C3%A7%C3%A3o-de-apis-rest-setembro-2019-1d4f6b6e8352
        // https://medium.com/@renato.groffe/asp-net-core-2-1-preview-2-e-utilizando-httpclient-factory-d3e7b7c7ba03
        private readonly IHttpClientFactory _iHttpClientFactory;
        // private readonly ICatalogService _iCatalogService;
        // private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        public CatalogService(IHttpClientFactory iHttpClientFactory
        // ,HttpClient httpClient
        )
        {
            _iHttpClientFactory = iHttpClientFactory;
            // _httpClient = httpClient;
        }

        public Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> GetPage()
        {
            // Content from BBC One: Dr. Who website (©BBC)
            var requestUri = "https://www.bbc.co.uk/programmes/b006q2x0";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            
            var client = _iHttpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }
        }


        // public async Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type)
        // {
        //     // var uri = API.Catalog.GetAllCatalogItems(_remoteServiceBaseUrl, page, take, brand, type);
        //     var uri = "http://google.com.br/?q=Nelson";

        //     var responseString = await _httpClient.GetStringAsync(uri);
        //     // var responseString = await _iCatalogService.GetStringAsync(uri);
            
        //     var catalog = JsonConvert.DeserializeObject<Catalog>(responseString);
        //     return catalog;
        // }
    }
}