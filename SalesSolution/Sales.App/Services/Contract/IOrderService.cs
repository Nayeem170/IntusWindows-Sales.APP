using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
    }
}
