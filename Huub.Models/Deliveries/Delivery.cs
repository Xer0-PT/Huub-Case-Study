using Huub.Models.Products;
using System.Text.Json.Serialization;

namespace Huub.Models.Deliveries
{
    public class Delivery
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
        [JsonPropertyName("shipped")]
        public bool Shipped { get; set; }
        [JsonPropertyName("products")]
        public List<Product> Products { get; set; }

        public Delivery()
        {
            Products = new List<Product>();
        }
    }
    public class ParseDeliveries
    {
        [JsonPropertyName("data")]
        public List<Delivery> Deliveries { get; set; } = new List<Delivery>();
    }
}
