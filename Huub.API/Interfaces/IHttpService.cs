using Huub.Models.Deliveries;
using Huub.Models.Orders;

namespace Huub.API.Interfaces
{
    public interface IHttpService
    {
        Task<List<Order>> GetOrders();
        Task<List<Delivery>> GetDeliveries();
    }
}
