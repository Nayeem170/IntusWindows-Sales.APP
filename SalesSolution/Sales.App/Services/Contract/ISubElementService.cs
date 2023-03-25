using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface ISubElementService
    {
        Task<IEnumerable<SubElementDTO>> GetSubElements(Guid windowId);
    }
}
