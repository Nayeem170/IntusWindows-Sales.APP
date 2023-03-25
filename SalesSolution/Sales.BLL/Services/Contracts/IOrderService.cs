using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order?> GetOrderAsync(Guid uid);
        Task<Order> AddOrderAsync(Order order);
        Order EditOrder(Order order);
        Task<bool> DeleteOrderAsync(Guid uid);
    }
}
