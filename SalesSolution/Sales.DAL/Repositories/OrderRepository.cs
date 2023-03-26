using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Extentions;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class OrderRepository : GenericRepository<Order, SalesDbContext>, IOrderRepository
    {
        public OrderRepository(SalesDbContext context) : base(context) { }

        public IQueryable<Order> GetAllIncludeAll()
        {
            return base.GetAll()
                .IncludeAll();
        }

        public Order? GetIncludeAll(Guid uid)
        {
            return base.GetAll()
                .Where(order => order.UId == uid)
                .IncludeAll()
                .FirstOrDefault();
        }
    }
}
