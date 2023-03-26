using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface ISubElementService
    {
        Task<IEnumerable<SubElementDTO>> GetSubElements(Guid windowId);
        Task<bool> AddSubElement(SubElementDTO subElementDTO);
        Task<bool> EditSubElement(SubElementDTO subElementDTO);
        Task<bool> DeleteSubElement(SubElementDTO subElementDTO);
    }
}
