using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;
using Sales.LIB.Extentions;

namespace Sales.BLL.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository windowRepository;

        public WindowService(IWindowRepository windowRepository)
        {
            this.windowRepository = windowRepository;
        }

        public IEnumerable<Window> GetWindows()
        {
            return windowRepository.GetAll();
        }

        public IEnumerable<Window> GetWindows(Guid orderId)
        {
            return windowRepository.GetAll(orderId);
        }

        public Window? GetWindow(Guid uid)
        {
            return windowRepository.Get(uid);
        }

        public Window AddWindow(Window window)
        {
            return window == null ? throw new ArgumentNullException("Window can not be null")
                                    : windowRepository.Add(window);
        }

        public Window EditWindow(Window window)
        {
            return window == null ? throw new ArgumentNullException("Window can not be null")
                                  : windowRepository.Edit(window);
        }

        public bool DeleteWindow(Guid uid)
        {
            var window = GetWindow(uid);
            if (!window.IsNull())
            {
                return windowRepository.Delete(window);
            }
            return false;
        }
    }
}
