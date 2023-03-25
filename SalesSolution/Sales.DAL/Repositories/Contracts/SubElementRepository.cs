using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface ISubElementRepository
    {
        Task<IEnumerable<SubElement>> GetSubElements();
        Task<IEnumerable<SubElement>> GetSubElements(Guid windowId);
        Task<SubElement?> GetSubElement(Guid uid);
    }
}
