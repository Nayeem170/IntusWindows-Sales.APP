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
        public ActionResult<IEnumerable<WindowDTO>> GetWindows()
        {
            try
            {
                var windows = windowService.GetWindows();

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
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Sorry, we can't retrive windows at the moment.");
            }
        }

        [HttpGet("for/{orderId:guid}")]
        public ActionResult<IEnumerable<WindowDTO>> GetWindows([FromRoute] Guid orderId)
        {
            try
            {
                var windows = windowService.GetWindows(orderId);

                if (windows.IsNullOrEmpty())
                {
                    Log.Debug($"We couldn't locate the windows associated with the orderId: {orderId}");
                    return NotFound();
                }
                else
                {
                    var windowDTOs = windows.ConvertToDto();
                    return Ok(windowDTOs);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Sorry, we can't retrive windows at the moment.");
            }
        }

        [HttpGet("{uid:guid}")]
        public ActionResult<IEnumerable<WindowDTO>> GetWindow(Guid orderId)
        {
            try
            {
                var window = windowService.GetWindow(orderId);

                if (window.IsNull())
                {
                    return NotFound();
                }
                else
                {
                    var windowDTO = window.ConvertToDto();
                    return Ok(windowDTO);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Sorry, we can't find window at the moment.");
            }
        }

        [HttpPost]
        public ActionResult<IEnumerable<WindowDTO>> AddWindow([FromBody] WindowDTO windowDTO)
        {
            try
            {
                var window = windowDTO.ConvertToModel();
                window = windowService.AddWindow(window);
                windowDTO = window.ConvertToDto();
                return Ok(windowDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't create window at the moment."));
            }
        }
        [HttpPut]
        public ActionResult<IEnumerable<WindowDTO>> EditWindow([FromBody] WindowDTO windowDTO)
        {
            try
            {
                var window = windowDTO
                    .ConvertToModel()
                    .ClearSubElements();
                window = windowService.EditWindow(window);
                windowDTO = window.ConvertToDto();
                return Ok(windowDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't update window at the moment."));
            }
        }

        [HttpDelete("{uid:guid}")]
        public ActionResult DeleteWindow([FromRoute] Guid uid)
        {
            try
            {
                windowService.DeleteWindow(uid);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't delete window at the moment."));
            }
        }
    }
}
