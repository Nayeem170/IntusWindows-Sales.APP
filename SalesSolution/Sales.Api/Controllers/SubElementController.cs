using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.API.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DTO.Models;
using Sales.LIB.Extentions;

namespace Sales.API.Controllers
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
        public ActionResult<IEnumerable<SubElement>> GetSubElements()
        {
            try
            {
                var subElements = subElementService.GetSubElements();

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

        [HttpGet("for/{windowId:guid}")]
        public ActionResult<IEnumerable<SubElement>> GetSubElements(Guid windowId)
        {
            try
            {
                var subElements = subElementService.GetSubElements(windowId);

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
        public ActionResult<IEnumerable<SubElementDTO>> GetSubElement(Guid uid)
        {
            try
            {
                var subElement = subElementService.GetSubElement(uid);

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
