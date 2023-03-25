using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface IWindowService
    {
        Task<IEnumerable<WindowDTO>> GetWindows(Guid orderId);
    }
}
