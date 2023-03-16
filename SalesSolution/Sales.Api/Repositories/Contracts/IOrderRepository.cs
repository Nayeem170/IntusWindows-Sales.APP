using Sales.Api.Entities;

namespace Sales.Api.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrder(Guid uid);
    }
}
