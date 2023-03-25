
using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;
using Sales.LIB.Extentions;

namespace Sales.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await orderRepository.GetOrdersAsync();
        }

        public async Task<Order?> GetOrderAsync(Guid uid)
        {
            return await orderRepository.GetOrderIncludeAllAsync(uid);
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            return await orderRepository.AddOrderAsync(order);
        }

        public Order EditOrder(Order order)
        {
            return orderRepository.EditOrder(order);
        }

        public async Task<bool> DeleteOrderAsync(Guid uid)
        {
            var order = await GetOrderAsync(uid);
            if (!order.IsNull())
            {
                return orderRepository.DeleteOrder(order);
            }
            return false;
        }
    }
}
