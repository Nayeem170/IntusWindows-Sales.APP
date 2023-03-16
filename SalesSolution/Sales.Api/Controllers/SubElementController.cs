using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.Api.Entities;
using Sales.Api.Extentions;
using Sales.Api.Repositories;
using Sales.Api.Repositories.Contracts;
using Sales.Models.DTOs;

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementRepository subElementRepository;

        public SubElementController(ISubElementRepository subElementRepository)
        {
            this.subElementRepository = subElementRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubElement>>> GetSubElements()
        {
            try
            {
                var subElements = await subElementRepository.GetSubElements();

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
                var subElement = await subElementRepository.GetSubElement(uid);

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
