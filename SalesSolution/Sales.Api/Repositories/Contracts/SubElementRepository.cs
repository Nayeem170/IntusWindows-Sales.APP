using Sales.Api.Entities;

namespace Sales.Api.Repositories.Contracts
{
    public interface ISubElementRepository
    {
        Task<IEnumerable<SubElement>> GetSubElements();
        Task<SubElement?> GetSubElement(Guid uid);
    }
}
