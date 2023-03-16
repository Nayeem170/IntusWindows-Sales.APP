﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sales.Api.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.Model.DTOs;

namespace Sales.Api.Controllers
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
        public async Task<ActionResult<IEnumerable<ElementTypeDTO>>> GetOrders()
        {
            try
            {
                var elementTypes = await elementTypeService.GetElementTypes();

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
                var elementType = await elementTypeService.GetElementType(uid);

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
