using Microsoft.EntityFrameworkCore;
using Sales.Api.Data;
using Sales.Api.Entities;
using Sales.Api.Extentions;
using Sales.Api.Repositories.Contracts;

namespace Sales.Api.Repositories
{
    public class WindowRepository : IWindowRepository
    {
        private readonly SalesDbContext salesDbContext;

        public WindowRepository(SalesDbContext salesDbContext)
        {
            this.salesDbContext = salesDbContext;
        }

        public async Task<IEnumerable<Window>> GetWindows()
        {
            return await salesDbContext.Windows
                .IncludeAll()
                .ToListAsync();
        }

        public async Task<Window?> GetWindow(Guid uid)
        {
            return await salesDbContext.Windows
                .Where(window => window.UId == uid)
                .IncludeAll()
                .FirstOrDefaultAsync();
        }
    }
}
