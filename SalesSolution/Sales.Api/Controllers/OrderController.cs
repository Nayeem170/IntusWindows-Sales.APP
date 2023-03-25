using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.API.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DTO.Models;
using Sales.LIB.Extentions;
using Serilog;

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
                var orders = await orderService.GetOrdersAsync();

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
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't retrive orders at the moment."));
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrder([FromRoute] Guid uid)
        {
            try
            {
                var order = await orderService.GetOrderAsync(uid);

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
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't find order at the moment."));
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> AddOrder([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var order = orderDTO.ConvertToModel();
                order = await orderService.AddOrderAsync(order);
                orderDTO = order.ConvertToDto();
                return Ok(orderDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't create order at the moment."));
            }
        }
        [HttpPut]
        public ActionResult<IEnumerable<OrderDTO>> EditOrder([FromBody] OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {
                var order = orderDTO.ConvertToModel();
                order = orderService.EditOrder(order);
                orderDTO = order.ConvertToDto();
                return Ok(orderDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't update order at the moment."));
            }
        }

        [HttpDelete("{uid:guid}")]
        public async Task<ActionResult> DeleteOrderAsync([FromRoute] Guid uid)
        {
            try
            {
                await orderService.DeleteOrderAsync(uid);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't update order at the moment."));
            }
        }
    }
}
