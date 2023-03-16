using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IWindowRepository
    {
        Task<IEnumerable<Window>> GetWindows();
        Task<Window?> GetWindow(Guid uid);
    }
}
