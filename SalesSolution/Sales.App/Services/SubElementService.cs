using MatBlazor;
using Newtonsoft.Json;
using Sales.APP.Extentions;
using Sales.APP.Services.Contract;
using Sales.DTO.Models;
using System.Net;
using System.Net.Http.Json;

namespace Sales.APP.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly HttpClient httpClient;
        private readonly IMatToaster toaster;

        public SubElementService(
            HttpClient httpClient,
            IMatToaster toaster)
        {
            this.httpClient = httpClient;
            this.toaster = toaster;
        }

        public async Task<IEnumerable<SubElementDTO>> GetSubElements(Guid windowId)
        {
            try
            {
                var subElements = await httpClient.GetFromJsonAsync<IEnumerable<SubElementDTO>>($"api/SubElements/for/{windowId}");
                return subElements;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(GetSubElements)}.", ex);
            }

            return new List<SubElementDTO>();
        }

        public async Task<bool> AddSubElement(SubElementDTO subElementDTO)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/SubElements", subElementDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<SubElementDTO>(responseBody);
                    return true;
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponseDto>(responseBody);
                    toaster.BadRequest(errorResponse.Error);
                    return false;
                }
                else
                {
                    Console.WriteLine("Failed to create sub element");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(AddSubElement)}.", ex);
            }

            return false;
        }

        public async Task<bool> EditSubElement(SubElementDTO subElementDTO)
        {
            try
            {
                var response = await httpClient.PutAsJsonAsync("api/SubElements", subElementDTO);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<SubElementDTO>(responseBody);
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to edit sub elements");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(EditSubElement)}.", ex);
            }

            return false;
        }

        public async Task<bool> DeleteSubElement(SubElementDTO subElement)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/SubElements/{subElement.UId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Failed to delete sub element");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while {nameof(DeleteSubElement)}.", ex);
            }

            return false;
        }
    }
}
