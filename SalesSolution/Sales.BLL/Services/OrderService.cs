
using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await orderRepository.GetOrders();
        }

        public async Task<Order?> GetOrder(Guid uid)
        {
            return await orderRepository.GetOrder(uid);
        }


    }
}
