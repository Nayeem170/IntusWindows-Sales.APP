using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.API.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DTO.Models;
using Sales.LIB.Extentions;

namespace Sales.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ElementTypeController : ControllerBase
    {
        private readonly IElementTypeService elementTypeService;

        public ElementTypeController(IElementTypeService elementTypeService)
        {
            this.elementTypeService = elementTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ElementTypeDTO>> GetElementTypes()
        {
            try
            {
                var elementTypes = elementTypeService.GetElementTypes();

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
                    "Sorry, we can't retrive element types at the moment.");
            }
        }

        [HttpGet("{uid:guid}")]
        public ActionResult<IEnumerable<ElementTypeDTO>> GetElementType(Guid uid)
        {
            try
            {
                var elementType = elementTypeService.GetElementType(uid);

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
                    "Sorry, we can't retrive element types at the moment.");
            }
        }
    }
}
