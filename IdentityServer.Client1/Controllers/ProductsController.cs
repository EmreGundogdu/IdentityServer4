using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Client1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IConfiguration configuration;

        public ProductsController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            var discoveryEndpoint = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (discoveryEndpoint.IsError)
            {

            }
            ClientCredentialsTokenRequest clientCredentialsTokenRequest = new();
            clientCredentialsTokenRequest.ClientId = configuration["Client:ClientId"];
            clientCredentialsTokenRequest.ClientSecret = configuration["Client:ClientSecret"];
            clientCredentialsTokenRequest.Address = discoveryEndpoint.TokenEndpoint;
            var token =await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
            if (token.IsError)
            {

            }
            httpClient.SetBearerToken(token.AccessToken);
            var response = await httpClient.GetAsync("https://localhost:5016/api/products/getproducts");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
            }
            return View();
        }
    }
}
