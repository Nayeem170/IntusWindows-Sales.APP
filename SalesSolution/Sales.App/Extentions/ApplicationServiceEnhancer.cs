using Sales.APP.Services;
using Sales.APP.Services.Contract;

namespace Sales.APP.Extentions
{
    public static class ApplicationServiceEnhancer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IWindowService, WindowService>();
            services.AddScoped<ISubElementService, SubElementService>();
        }
    }
}
