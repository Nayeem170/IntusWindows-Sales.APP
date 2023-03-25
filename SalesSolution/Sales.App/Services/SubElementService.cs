using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using System.Net.Http.Json;

namespace Sales.APP.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly HttpClient httpClient;

        public SubElementService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<SubElementDTO>> GetSubElements(Guid windowId)
        {
            try
            {
                var subElements = await httpClient.GetFromJsonAsync<IEnumerable<SubElementDTO>>($"api/SubElements/for/{windowId}");
                return subElements;
            }
            catch (Exception)
            {
                // Log exception
            }

            return new List<SubElementDTO>();
        }
    }
}
