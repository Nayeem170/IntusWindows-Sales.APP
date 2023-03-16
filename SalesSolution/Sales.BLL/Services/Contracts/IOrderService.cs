using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order?> GetOrder(Guid uid);
    }
}
