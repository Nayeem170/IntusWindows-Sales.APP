using Microsoft.EntityFrameworkCore;
using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Extentions;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
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
