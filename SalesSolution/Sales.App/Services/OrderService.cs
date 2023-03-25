using Newtonsoft.Json;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using System.Diagnostics;
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

        public async Task<bool> AddOrder(OrderDTO orderDTO)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<OrderDTO>("api/Orders", orderDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    orderDTO = JsonConvert.DeserializeObject<OrderDTO>(responseBody);
                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed to create order");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception thrown while {nameof(AddOrder)}.", ex);
                throw;
            }
        }

        public async Task<bool> EditOrder(OrderDTO orderDTO)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync<OrderDTO>("api/Orders", orderDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    orderDTO = JsonConvert.DeserializeObject<OrderDTO>(responseBody);
                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed to edit order");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception thrown while {nameof(EditOrder)}.", ex);
                throw;
            }
        }

        public async Task<bool> DeleteOrder(OrderDTO orderDTO)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Orders/{orderDTO.UId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed to delete order");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception thrown while {nameof(DeleteOrder)}.", ex);
                throw;
            }
        }
    }
}
