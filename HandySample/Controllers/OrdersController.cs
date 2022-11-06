using CategoryService.Api.Validation.Attributes;
using HandySample.ApiModels;
using HandySample.ApiModels.ModelBinders;
using HandySample.ApiModels.Requests;
using HandySample.ApiModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HnadySample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetOrders")]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public IActionResult GetOrders([ModelBinder(Name= "orderCode", BinderType = typeof(OrderCodeModelBinder))] OrderCodeRequest? orderCode = null)
        {
            return Ok("Hello world");
        }

    }
}