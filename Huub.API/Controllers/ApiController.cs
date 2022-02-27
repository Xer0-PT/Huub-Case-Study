using Huub.API.Interfaces;
using Huub.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Huub.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IService service;

        public ApiController(IService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Get a list of orders and its deliveries from a given brand id.
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [SwaggerOperation("Get a list of orders and its deliveries from a given brand id.", null, Tags = new[] { "Huub Case Study API" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<OrderDeliveriesDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("brand")]
        public async Task<List<OrderDeliveriesDto>> Get([Required]int brandId)
            => await service.GetOrdersAndDeliveries(brandId);


        /// <summary>
        /// Get a list of products and their total quantity from a given order id or reference that has been shipped.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderReference"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [SwaggerOperation("Get a list of products and their total quantity from a given order id or reference that has been shipped.", null, Tags = new[] { "Huub Case Study API" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<ProductDeliveredDto>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet]
        [Route("delivered-products")]
        public async Task<List<ProductDeliveredDto>> Get(int? orderId, string? orderReference)
        {
            if (!orderId.HasValue && orderReference == null)
                throw new ArgumentNullException("You should input an order id or an order reference!");

            return await service.GetProductsDelivered(orderId, orderReference);
        }
    }
}