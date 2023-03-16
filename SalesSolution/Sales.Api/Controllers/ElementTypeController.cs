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
    public class ElementTypeController : ControllerBase
    {
        private readonly IElementTypeRepository elementTypeRepository;

        public ElementTypeController(IElementTypeRepository elementTypeRepository)
        {
            this.elementTypeRepository = elementTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElementTypeDTO>>> GetOrders()
        {
            try
            {
                var elementTypes = await elementTypeRepository.GetElementTypes();

                if (elementTypes.IsNullOrEmpty())
                {
                    return NotFound();
                }
                else
                {
                    var elementTypeDTOs = elementTypes.ConvertToDto();
                    return Ok(elementTypeDTOs);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retriving data from the database");
            }
        }

        [HttpGet("{uid:guid}")]
        public async Task<ActionResult<IEnumerable<ElementTypeDTO>>> GetElementType(Guid uid)
        {
            try
            {
                var elementType = await elementTypeRepository.GetElementType(uid);

                if (elementType.IsNull())
                {
                    return NotFound();
                }
                else
                {
                    var elementTypeDTO = elementType.ConvertToDto();
                    return Ok(elementTypeDTO);
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
