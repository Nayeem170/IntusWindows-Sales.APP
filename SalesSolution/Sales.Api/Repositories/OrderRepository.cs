using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;
using Sales.Api.Entities;
using Sales.Api.Extentions;
using Sales.Api.Repositories.Contracts;

namespace Sales.Api.Repositories
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
                .IncludeAll()
                .ToListAsync();
        }

        public async Task<Order?> GetOrder(Guid uid)
        {
            return await salesDbContext.Orders
                .Where(order => order.UId == uid)
                .IncludeAll()
                .FirstOrDefaultAsync();
        }
    }
}
