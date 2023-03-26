using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order? GetOrder(Guid uid);
        Order AddOrder(Order order);
        Order EditOrder(Order order);
        bool DeleteOrder(Guid uid);
    }
}
