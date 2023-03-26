using Sales.DTO.Models;

namespace Sales.APP.Services.Contract
{
    public interface IWindowService
    {
        Task<IEnumerable<WindowDTO>> GetWindows(Guid orderId);
        Task<bool> DeleteWindow(WindowDTO window);
        Task<bool> AddWindow(WindowDTO windowDTO);
        Task<bool> EditWindow(WindowDTO windowDTO);
    }
}
