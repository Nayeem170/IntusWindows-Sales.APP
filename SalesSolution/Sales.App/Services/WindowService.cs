using Newtonsoft.Json;
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
                Console.WriteLine($"Exception thrown while {nameof(GetWindows)}.", ex);
            }

            return new List<WindowDTO>();
        }

        public async Task<bool> AddWindow(WindowDTO windowDTO)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync<WindowDTO>("api/Windows", windowDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<WindowDTO>(responseBody);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to create window");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(AddWindow)}.", ex);
            }

            return false;
        }

        public async Task<bool> EditWindow(WindowDTO windowDTO)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync<WindowDTO>("api/Windows", windowDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<WindowDTO>(responseBody);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to edit window");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(EditWindow)}.", ex);
            }

            return false;
        }

        public async Task<bool> DeleteWindow(WindowDTO window)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/Windows/{window.UId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to delete window");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(DeleteWindow)}.", ex);
            }

            return false;
        }
    }
}
