using System.Text.Json.Serialization;

namespace Huub.Models.Orders
{
    public class Order
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("brand_id")]
        public int BrandId { get; set; }
        [JsonPropertyName("customer_name")]
        public string? CustomerName { get; set; }
        [JsonPropertyName("reference")]
        public string? Reference { get; set; }
        [JsonPropertyName("order_date")]
        public string? OrderDate { get; set; }
        [JsonPropertyName("price_total")]
        public float PriceTotal { get; set; }
    }
    public class ParseOrders
    {
        [JsonPropertyName("data")]
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
