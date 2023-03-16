using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;
using Sales.Api.Entities;
using Sales.Api.Extentions;
using Sales.Api.Repositories.Contracts;

namespace Sales.Api.Repositories
{
    public class SubElementRepository : ISubElementRepository
    {
        private readonly SalesDbContext salesDbContext;

        public SubElementRepository(SalesDbContext salesDbContext)
        {
            this.salesDbContext = salesDbContext;
        }
        public async Task<IEnumerable<SubElement>> GetSubElements()
        {
            return await salesDbContext.SubElements
                .IncludeAll()
                .ToListAsync();
        }

        public async Task<SubElement?> GetSubElement(Guid uid)
        {
            return await salesDbContext.SubElements
                .Where(subElement => subElement.UId == uid)
                .IncludeAll()
                .FirstOrDefaultAsync();
        }

    }
}
