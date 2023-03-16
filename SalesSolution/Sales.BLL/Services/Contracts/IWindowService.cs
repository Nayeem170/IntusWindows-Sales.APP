using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IWindowService
    {
        Task<IEnumerable<Window>> GetWindows();
        Task<Window?> GetWindow(Guid uid);
    }
}
