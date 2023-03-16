using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.BLL.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository windowRepository;

        public WindowService(IWindowRepository windowRepository)
        {
            this.windowRepository = windowRepository;
        }

        public async Task<IEnumerable<Window>> GetWindows()
        {
            return await windowRepository.GetWindows();
        }

        public Task<Window?> GetWindow(Guid uid)
        {
            return windowRepository.GetWindow(uid);
        }
    }
}
