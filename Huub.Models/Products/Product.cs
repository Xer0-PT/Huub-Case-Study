using System.Text.Json.Serialization;

namespace Huub.Models.Products
{
    public class Product
    {
        [JsonPropertyName("product_name")]
        public string? ProductName { get; set; }
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
