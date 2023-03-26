using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllIncludeAll();
        Order? GetIncludeAll(Guid uid);
    }
}
