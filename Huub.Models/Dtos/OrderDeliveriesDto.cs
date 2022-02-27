using Huub.Models.Deliveries;
using Huub.Models.Orders;

namespace Huub.Models.Dtos
{
    public class OrderDeliveriesDto
    {
        public OrderDeliveriesDto()
        {
            Order = new Order();
            Deliveries = new List<Delivery>();
        }
        public Order Order { get; set; }
        public List<Delivery> Deliveries { get; set; }
    }
}
