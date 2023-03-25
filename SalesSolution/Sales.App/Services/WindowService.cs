using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using System.Net.Http.Json;

namespace Sales.APP.Services
{
    public class WindowService : IWindowService
    {
        private readonly HttpClient httpClient;

        public WindowService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<WindowDTO>> GetWindows(Guid orderId)
        {
            try
            {
                var windows = await httpClient.GetFromJsonAsync<IEnumerable<WindowDTO>>($"api/Windows/for/{orderId}");
                return windows;
            }
            catch (Exception ex)
            {
                return new List<WindowDTO>();
            }
        }
    }
}
