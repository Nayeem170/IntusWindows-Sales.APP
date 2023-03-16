using Sales.Api.Repositories.Contracts;
using Sales.Api.Repositories;
using Sales.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Sales.Api.Extentions
{
    public static class ApplicationServiceEnhancer
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<SalesDbContext>(options =>
                options.UseSqlServer(connectionString)
            );
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IWindowRepository, WindowRepository>();
            services.AddScoped<ISubElementRepository, SubElementRepository>();
            services.AddScoped<IElementTypeRepository, ElementTypeRepository>();
        }
    }
}
