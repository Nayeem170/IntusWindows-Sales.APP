using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersIncludeAll();
        Task<Order?> GetOrderIncludeAllAsync(Guid uid);
        Task<Order> AddOrderAsync(Order order);
        Order EditOrder(Order order);
        bool DeleteOrder(Order order);
    }
}
