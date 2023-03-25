using Microsoft.EntityFrameworkCore;
using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Extentions;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SalesDbContext salesDbContext;

        public OrderRepository(SalesDbContext salesDbContext)
        {
            this.salesDbContext = salesDbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await salesDbContext.Orders
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersIncludeAll()
        {
            return await salesDbContext.Orders
                .IncludeAll()
                .ToListAsync();
        }

        public async Task<Order?> GetOrderIncludeAllAsync(Guid uid)
        {
            return await salesDbContext.Orders
                .Where(order => order.UId == uid)
                .IncludeAll()
                .FirstOrDefaultAsync();
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            await salesDbContext.Orders.AddAsync(order);
            salesDbContext.SaveChanges();
            return order;
        }

        public Order EditOrder(Order order)
        {
            salesDbContext.Entry(order).State = EntityState.Modified;
            salesDbContext.SaveChanges();
            return order;
        }

        public bool DeleteOrder(Order order)
        {
            salesDbContext.Orders.Remove(order);
            return salesDbContext.SaveChanges() == 1;
        }
    }
}
