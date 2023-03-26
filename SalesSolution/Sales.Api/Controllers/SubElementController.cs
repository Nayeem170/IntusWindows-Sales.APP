using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.API.Extentions;
using Sales.BLL.Exceptions;
using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DTO.Models;
using Sales.LIB.Extentions;
using Serilog;

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

        [HttpPost]
        public ActionResult<IEnumerable<SubElementDTO>> AddSubElement([FromBody] SubElementDTO subElementDTO)
        {
            try
            {
                var subElement = subElementDTO.ConvertToModel();
                subElement = subElementService.AddSubElement(subElement);
                subElementDTO = subElement.ConvertToDto();
                return Ok(subElementDTO);
            }
            catch (BLLValidationException ex)
            {
                return BadRequest(new ErrorResponseDto(ex.Message));
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't create sub element at the moment."));
            }
        }
        [HttpPut]
        public ActionResult<IEnumerable<SubElementDTO>> EditWindow([FromBody] SubElementDTO subElementDTO)
        {
            try
            {
                var subElement = subElementDTO.ConvertToModel();
                subElement = subElementService.EditSubElement(subElement);
                subElementDTO = subElement.ConvertToDto();
                return Ok(subElementDTO);
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't update sub element at the moment."));
            }
        }

        [HttpDelete("{uid:guid}")]
        public ActionResult DeleteSubElement([FromRoute] Guid uid)
        {
            try
            {
                subElementService.DeleteSubElement(uid);
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}", ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ErrorResponseDto("Sorry, we can't delete sub element at the moment."));
            }
        }
    }
}
