using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<bool> AddOrder(OrderDTO orderDTO);
        Task<bool> EditOrder(OrderDTO orderDTO);
        Task<bool> DeleteOrder(OrderDTO orderDTO);
    }
}
