using HandySample.ApiModels;
using HandySample.ApiModels.MoedlValidations;
using HandySample.ApiModels.Requests;
using HandySample.ApiModels.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HnadySample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet("SayHello")]
        public IActionResult SayHello()
        {
            return Ok("Hello world");
        }

        [HttpGet("GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ListResponse<UserResponse>))]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public IActionResult GetCustomers(
            [FromQuery][PageNumberRange] int pageNumber, 
            [FromQuery] string? search)
        {
            var list = new List<UserResponse>()
            {
                new UserResponse()
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    FullName= "mahdi",
                    UserName = "mahdiradi"
                }
            };

            return Ok(new ListResponse<UserResponse>
            {
                Items = list,
                TotalCount = list.Count()
            });
        }


        [HttpGet("GetCustomer/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public IActionResult GetCustomer([FromRoute] int userId)
        {
            var item = new UserResponse()
            {
                Id = userId,
                CreatedDate = DateTime.Now,
                FullName = "mahdi",
                UserName = "mahdiradi"
            };

            return Ok(item);
        }

        [HttpPost("CreateCustomer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public IActionResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            return Created("http://localhost:7000/Customers/GetCustomer/1", null);
        }
    }
}