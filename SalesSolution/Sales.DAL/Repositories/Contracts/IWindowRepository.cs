using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IWindowRepository : IRepository<Window>
    {
        IQueryable<Window> GetAll(Guid orderId);
        IQueryable<Window> GetAllIncludeAll();
        Window? GetIncludeAll(Guid uid);
    }
}
