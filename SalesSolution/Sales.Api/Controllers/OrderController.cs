using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.API.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DTO.Models;

namespace Sales.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            try
            {
                var orders = await orderService.GetOrders();

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
                var order = await orderService.GetOrder(uid);

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
