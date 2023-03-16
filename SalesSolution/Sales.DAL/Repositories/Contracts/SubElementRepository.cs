using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface ISubElementRepository
    {
        Task<IEnumerable<SubElement>> GetSubElements();
        Task<SubElement?> GetSubElement(Guid uid);
    }
}
