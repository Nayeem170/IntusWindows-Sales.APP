using Microsoft.EntityFrameworkCore;
using Sales.DAL.Data;
using Sales.DAL.Entities;
using Sales.DAL.Extentions;
using Sales.DAL.Repositories.Contracts;

namespace Sales.DAL.Repositories
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
                .ToListAsync();
        }

        public async Task<IEnumerable<Window>> GetWindows(Guid orderId)
        {
            return await salesDbContext.Windows
                .Where(window => window.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Window>> GetWindowsIncludeAll()
        {
            return await salesDbContext.Windows
                .IncludeAll()
                .ToListAsync();
        }

        public async Task<Window?> GetWindowIncludeAll(Guid uid)
        {
            return await salesDbContext.Windows
                .Where(window => window.UId == uid)
                .IncludeAll()
                .FirstOrDefaultAsync();
        }
    }
}
