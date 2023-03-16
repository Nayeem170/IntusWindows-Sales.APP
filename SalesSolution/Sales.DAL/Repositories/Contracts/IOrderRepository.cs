using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrder(Guid uid);
    }
}
