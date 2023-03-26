using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class ElementTypeRepository : GenericRepository<ElementType, SalesDbContext>, IElementTypeRepository
    {
        public ElementTypeRepository(SalesDbContext context) : base(context) { }
        public override IQueryable<ElementType> GetAll()
        {
            return base.GetAll()
                .OrderBy(type => type.Name);
        }
    }
}
