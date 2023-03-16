using Microsoft.EntityFrameworkCore;
using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
{
    public class ElementTypeRepository : IElementTypeRepository
    {
        private readonly SalesDbContext salesDbContext;

        public ElementTypeRepository(SalesDbContext salesDbContext)
        {
            this.salesDbContext = salesDbContext;
        }

        public async Task<IEnumerable<ElementType>> GetElementTypes()
        {
            return await salesDbContext.ElementTypes
                .ToListAsync();
        }

        public async Task<ElementType?> GetElementType(Guid uid)
        {
            return await salesDbContext.ElementTypes
                .Where(type => type.UId == uid)
                .FirstOrDefaultAsync();
        }
    }
}
