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
        public ActionResult<IEnumerable<OrderDTO>> GetOrders()
        {
            try
            {
                var orders = orderService.GetOrders();

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
        public ActionResult<IEnumerable<OrderDTO>> GetOrder([FromRoute] Guid uid)
        {
            try
            {
                var order = orderService.GetOrder(uid);

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
        public ActionResult<IEnumerable<OrderDTO>> AddOrder([FromBody] OrderDTO orderDTO)
        {
            try
            {
                var order = orderDTO.ConvertToModel();
                order = orderService.AddOrder(order);
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
        public ActionResult DeleteOrder([FromRoute] Guid uid)
        {
            try
            {
                orderService.DeleteOrder(uid);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't delete order at the moment."));
            }
        }
    }
}
