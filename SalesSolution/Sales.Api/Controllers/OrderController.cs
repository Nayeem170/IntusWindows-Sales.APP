using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.Api.Extentions;
using Sales.Api.Repositories.Contracts;
using Sales.Models.DTOs;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            try
            {
                var orders = await orderRepository.GetOrders();

                if (orders.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    var orderDTOs = orders.ConvertToDto();
                    return Ok(orderDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "Error retriving data from the database");
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrder(Guid uid)
        {
            try
            {
                var order = await orderRepository.GetOrder(uid);

                if (order.IsNull())
                {
                    return NotFound();
                }
                else
                {
                    var orderDTO = order.ConvertToDto();
                    return Ok(orderDTO);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
            }
        }
    }
}
