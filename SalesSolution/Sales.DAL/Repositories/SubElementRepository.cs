using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Extentions;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class SubElementRepository : GenericRepository<SubElement, SalesDbContext>, ISubElementRepository
    {
        public SubElementRepository(SalesDbContext context) : base(context) { }

        public override IQueryable<SubElement> GetAll()
        {
            return base.GetAll()
                .IncludeAll();
        }

        public IQueryable<SubElement> GetAll(Guid windowId)
        {
            return base.GetAll()
                .Where(subElement => subElement.WindowId == windowId)
                .IncludeAll();
        }

        public SubElement? GetIncludeAll(Guid uid)
        {
            return base.GetAll()
                .Where(order => order.UId == uid)
                .IncludeAll()
                .FirstOrDefault();
        }
    }
}
