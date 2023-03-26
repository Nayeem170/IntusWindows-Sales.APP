
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

        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetAll();
        }

        public Order? GetOrder(Guid uid)
        {
            return orderRepository.Get(uid);
        }

        public Order AddOrder(Order order)
        {
            return order == null ? throw new ArgumentNullException("Order can not be null")
                                 : orderRepository.Add(order);
        }

        public Order EditOrder(Order order)
        {
            return order == null ? throw new ArgumentNullException("Order can not be null")
                                 : orderRepository.Edit(order);
        }

        public bool DeleteOrder(Guid uid)
        {
            var order = GetOrder(uid);
            if (!order.IsNull())
            {
                return orderRepository.Delete(order);
            }
            return false;
        }
    }
}
