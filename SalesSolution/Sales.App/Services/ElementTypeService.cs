using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using System.Net.Http.Json;

namespace Sales.APP.Services
{
    public class ElementTypeService : IElementTypeService
    {
        private readonly HttpClient httpClient;

        public ElementTypeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ElementTypeDTO>> GetElementTypes()
        {
            try
            {
                var elementTypes = await httpClient.GetFromJsonAsync<IEnumerable<ElementTypeDTO>>($"api/ElementTypes");
                return elementTypes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(GetElementTypes)}.", ex);
            }

            return new List<ElementTypeDTO>();
        }
    }
}
