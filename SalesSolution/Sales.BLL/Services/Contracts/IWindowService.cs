using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IWindowService
    {
        Task<IEnumerable<Window>> GetWindows();
        Task<IEnumerable<Window>> GetWindows(Guid orderId);
        Task<Window?> GetWindow(Guid uid);
    }
}
