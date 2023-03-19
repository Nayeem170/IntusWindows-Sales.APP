using Microsoft.EntityFrameworkCore;
using Sales.BLL.Services;
using Sales.BLL.Services.Contracts;
using Sales.DAL.Data;
using Sales.DAL.Repositories;
using Sales.DAL.Repositories.Contracts;

namespace Sales.API.Extentions
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

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IWindowService, WindowService>();
            services.AddScoped<ISubElementService, SubElementService>();
            services.AddScoped<IElementTypeService, ElementTypeService>();
        }
    }
}
