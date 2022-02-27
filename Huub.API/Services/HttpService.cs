using Huub.API.Interfaces;
using Huub.Models.Deliveries;
using Huub.Models.Orders;
using System.Text.Json;

namespace Huub.API.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        public HttpService(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        /// <summary>
        /// Fetch deliveries JSON payload from Huub endpoint.
        /// </summary>
        /// <returns>List of Delivery entity.</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Delivery>> GetDeliveries()
        {
            using (var client = _httpClient.CreateClient())
            {
                var response = await client.GetAsync($"{_configuration.GetValue<string>("deliveries")}");
                
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<ParseDeliveries>(jsonString).Deliveries;
                }
            }
            throw new HttpRequestException("Service unavailable!");
        }


        /// <summary>
        /// Fetch orders JSON payload from Huub endpoint.
        /// </summary>
        /// <returns>List of Order entity.</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Order>> GetOrders()
        {
            using (var client = _httpClient.CreateClient())
            {
                var response = await client.GetAsync($"{_configuration.GetValue<string>("orders")}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<ParseOrders>(jsonString).Orders;
                }
            }
            throw new HttpRequestException("Service unavailable!");
        }
    }
}
