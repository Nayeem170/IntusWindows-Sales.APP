using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Extentions;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class WindowRepository : GenericRepository<Window, SalesDbContext>, IWindowRepository
    {
        public WindowRepository(SalesDbContext context) : base(context) { }

        public override IQueryable<Window> GetAll()
        {
            return base.GetAll()
                .IncludeSubElement();
        }

        public IQueryable<Window> GetAll(Guid orderId)
        {
            return base.GetAll()
                .Where(window => window.OrderId == orderId)
                .IncludeSubElement();
        }

        public IQueryable<Window> GetAllIncludeAll()
        {
            return base.GetAll()
                .IncludeAll();
        }

        public Window? GetIncludeAll(Guid uid)
        {
            return base.GetAll()
                .Where(window => window.UId == uid)
                .IncludeAll()
                .FirstOrDefault();
        }
    }
}
