using Huub.API.Interfaces;
using Huub.Models.Dtos;

namespace Huub.API.Services
{
    public class Service : IService
    {
        private readonly IHttpService _httpService;

        public Service(IHttpService httpService)
        {
            _httpService = httpService;
        }

        /// <summary>
        /// With brand as a query parameter, return a list of orders and its deliveries.
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns>Returns a List of OrderDeliveriesDto entity.</returns>
        public async Task<List<OrderDeliveriesDto>> GetOrdersAndDeliveries(int brandId)
        {
            var ordersList = await _httpService.GetOrders();
            var deliveriesList = await _httpService.GetDeliveries();

            return ordersList.FindAll(x => x.BrandId == brandId)
                            .Select(x => new OrderDeliveriesDto()
                            {
                                Order = x,
                                Deliveries = deliveriesList.FindAll(y => y.OrderId == x.Id)
                            })
                            .ToList();
        }


        /// <summary>
        /// With an id or reference of order as a query parameter, return the quantity
        /// of each product of that order that has already been shipped.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderReference"></param>
        /// <returns>Returns a List of ProductDeliveredDto entity.</returns>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task<List<ProductDeliveredDto>> GetProductsDelivered(int? orderId, string? orderReference)
        {
            var ordersList = await _httpService.GetOrders();
            var deliveriesList = await _httpService.GetDeliveries();

            var order = ordersList.FirstOrDefault(x => x.Id == orderId || x.Reference == orderReference);

            if (order == null)
            {
                string message;

                if (orderId.HasValue)
                    message = $"The order with {orderId} id cannot be found!";
                else
                    message = $"The order with {orderReference} reference cannot be found!";

                throw new BadHttpRequestException(message);
            }

            return deliveriesList.FindAll(x => x.OrderId == order.Id && x.Shipped)
                                    .SelectMany(x => x.Products)
                                    .GroupBy(x => x.ProductName)
                                    .Select(x => new ProductDeliveredDto()
                                    {
                                        ProductName = x.Key,
                                        TotalQuantity = x.Sum(x => x.Quantity),
                                    })
                                    .OrderBy(x => x.ProductName)
                                    .ToList();
        }
    }
}
