using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface IElementTypeService
    {
        Task<IEnumerable<ElementTypeDTO>> GetElementTypes();
    }
}
