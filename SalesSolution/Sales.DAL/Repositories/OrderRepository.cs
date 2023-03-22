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

        public async Task<IEnumerable<Order>> GetOrders()
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

        public async Task<Order?> GetOrderIncludeAll(Guid uid)
        {
            return await salesDbContext.Orders
                .Where(order => order.UId == uid)
                .IncludeAll()
                .FirstOrDefaultAsync();
        }
    }
}
