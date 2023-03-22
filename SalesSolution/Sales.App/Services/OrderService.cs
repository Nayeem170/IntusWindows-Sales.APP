using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using System.Net.Http.Json;

namespace Sales.APP.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient httpClient;

        public OrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            try
            {
                var orders = await httpClient.GetFromJsonAsync<IEnumerable<OrderDTO>>("api/Orders");
                return orders;
            }
            catch (Exception)
            {
                // Log exception
                throw;
            }
        }
    }
}
