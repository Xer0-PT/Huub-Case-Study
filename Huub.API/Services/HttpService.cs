using Huub.API.Interfaces;
using Huub.Models.Deliveries;
using Huub.Models.Orders;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Huub.API.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private const string OrdersKey = "ordersKey";
        private const string DeliveriesKey = "deliveriesKey";

        public HttpService(IHttpClientFactory httpClient, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _memoryCache = memoryCache;
        }


        /// <summary>
        /// Fetch deliveries JSON payload from Huub endpoint.
        /// </summary>
        /// <returns>List of Delivery entity.</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Delivery>> GetDeliveries()
        {
            if(_memoryCache.TryGetValue(DeliveriesKey, out List<Delivery> deliveries))
            {
                return deliveries;
            }

            using (var client = _httpClient.CreateClient())
            {
                var response = await client.GetAsync($"{_configuration.GetValue<string>("deliveries")}");
                
                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    deliveries = JsonSerializer.Deserialize<ParseDeliveries>(jsonString).Deliveries;

                    _memoryCache.Set(DeliveriesKey, deliveries);

                    return deliveries;
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
            if (_memoryCache.TryGetValue(OrdersKey, out List<Order> orders))
            {
                return orders;
            }

            using (var client = _httpClient.CreateClient())
            {
                var response = await client.GetAsync($"{_configuration.GetValue<string>("orders")}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    orders = JsonSerializer.Deserialize<ParseOrders>(jsonString).Orders;

                    _memoryCache.Set(OrdersKey, orders);

                    return orders;
                }
            }
            throw new HttpRequestException("Service unavailable!");
        }
    }
}
