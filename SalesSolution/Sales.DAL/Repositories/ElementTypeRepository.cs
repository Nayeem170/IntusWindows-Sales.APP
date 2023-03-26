using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class ElementTypeRepository : GenericRepository<ElementType, SalesDbContext>, IElementTypeRepository
    {
        public ElementTypeRepository(SalesDbContext context) : base(context) { }
    }
}
