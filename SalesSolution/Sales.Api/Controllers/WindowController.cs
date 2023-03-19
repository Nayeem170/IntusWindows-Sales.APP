using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.API.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DTO.Models;

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

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<IEnumerable<WindowDTO>>> GetWindow(Guid uid)
        {
            try
            {
                var window = await windowService.GetWindow(uid);

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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
            }
        }
    }
}
