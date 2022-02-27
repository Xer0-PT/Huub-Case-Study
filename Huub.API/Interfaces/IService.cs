using Huub.Models.Dtos;

namespace Huub.API.Interfaces
{
    public interface IService
    {
        Task<List<OrderDeliveriesDto>> GetOrdersAndDeliveries(int brandId);
        Task<List<ProductDeliveredDto>> GetProductsDelivered(int? orderId, string? orderReference);
    }
}
