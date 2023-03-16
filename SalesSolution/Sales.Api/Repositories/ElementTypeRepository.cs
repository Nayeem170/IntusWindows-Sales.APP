using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;
using Sales.Api.Entities;
using Sales.Api.Repositories.Contracts;

namespace Sales.Api.Repositories
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
