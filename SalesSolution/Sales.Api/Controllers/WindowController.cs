using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.Api.Extentions;
using Sales.Api.Repositories;
using Sales.Api.Repositories.Contracts;
using Sales.Models.DTOs;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowRepository windowRepository;

        public WindowController(IWindowRepository windowRepository)
        {
            this.windowRepository = windowRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WindowDTO>>> GetWindows()
        {
            try
            {
                var windows = await windowRepository.GetWindows();

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
                var window = await windowRepository.GetWindow(uid);

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
