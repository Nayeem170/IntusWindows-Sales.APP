using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IWindowRepository
    {
        Task<IEnumerable<Window>> GetWindows();
        Task<IEnumerable<Window>> GetWindowsForOrder(Guid orderId);
        Task<IEnumerable<Window>> GetWindowsIncludeAll();
        Task<Window?> GetWindow(Guid uid);
    }
}
