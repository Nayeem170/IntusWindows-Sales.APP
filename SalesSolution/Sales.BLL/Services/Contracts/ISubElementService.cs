using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface ISubElementService
    {
        Task<IEnumerable<SubElement>> GetSubElements();
        Task<IEnumerable<SubElement>> GetSubElements(Guid windowId);
        Task<SubElement?> GetSubElement(Guid uid);
    }
}
