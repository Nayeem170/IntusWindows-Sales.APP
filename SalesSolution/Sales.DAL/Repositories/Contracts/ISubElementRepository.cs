using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface ISubElementRepository : IRepository<SubElement>
    {
        IQueryable<SubElement> GetAll(Guid windowId);
        SubElement? GetIncludeAll(Guid uid);
    }
}
