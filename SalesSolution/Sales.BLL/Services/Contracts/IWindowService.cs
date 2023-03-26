using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IWindowService
    {
        IEnumerable<Window> GetWindows();
        IEnumerable<Window> GetWindows(Guid orderId);
        Window GetWindow(Guid uid);
        Window AddWindow(Window window);
        Window EditWindow(Window window);
        bool DeleteWindow(Guid uid);
    }
}
