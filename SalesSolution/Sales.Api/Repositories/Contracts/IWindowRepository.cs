using Sales.Api.Entities;

namespace Sales.Api.Repositories.Contracts
{
    public interface IWindowRepository
    {
        Task<IEnumerable<Window>> GetWindows();
        Task<Window?> GetWindow(Guid uid);
    }
}
