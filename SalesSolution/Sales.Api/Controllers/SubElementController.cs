using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.Api.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.Model.DTOs;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementService subElementService;

        public SubElementController(ISubElementService subElementService)
        {
            this.subElementService = subElementService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubElement>>> GetSubElements()
        {
            try
            {
                var subElements = await subElementService.GetSubElements();

                if (subElements.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    var subElementDTOs = subElements.ConvertToDto();
                    return Ok(subElementDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<IEnumerable<SubElementDTO>>> GetSubElement(Guid uid)
        {
            try
            {
                var subElement = await subElementService.GetSubElement(uid);

                if (subElement.IsNull())
                {
                    return NotFound();
                }
                else
                {
                    var subElementDTO = subElement.ConvertToDto();
                    return Ok(subElementDTO);
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
