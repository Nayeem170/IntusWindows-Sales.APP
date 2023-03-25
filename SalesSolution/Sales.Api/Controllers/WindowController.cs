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
    public class WindowController : ControllerBase
    {
        private readonly IWindowService windowService;

        public WindowController(IWindowService windowService)
        {
            this.windowService = windowService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowDTO>>> GetWindows()
        {
            try
            {
                var windows = await windowService.GetWindows();

                if (windows.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    var windowDTOs = windows.ConvertToDto();
                    return Ok(windowDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
            }
        }

        [HttpGet("for/{orderId:guid}")]
        public async Task<ActionResult<IEnumerable<WindowDTO>>> GetWindows(Guid orderId)
        {
            try
            {
                var windows = await windowService.GetWindows(orderId);

                if (windows.IsNullOrEmpty())
                {
                    Log.Debug($"We couldn't locate the windows associated with the orderId: {orderId}");
                    return NotFound();
                }
                else
                {
                    var windowDTOs = windows.ConvertToDtoWindowOnly();
                    return Ok(windowDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<IEnumerable<WindowDTO>>> GetWindow(Guid orderId)
        {
            try
            {
                var window = await windowService.GetWindow(orderId);

                if (window.IsNull())
                {
                    return NotFound();
                }
                else
                {
                    var windowDTO = window.ConvertToDtoWindowOnly();
                    return Ok(windowDTO);
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
