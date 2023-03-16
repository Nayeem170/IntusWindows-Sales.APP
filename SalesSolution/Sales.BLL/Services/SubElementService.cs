using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.BLL.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly ISubElementRepository subElementRepository;

        public SubElementService(ISubElementRepository subElementRepository)
        {
            this.subElementRepository = subElementRepository;
        }
        public async Task<IEnumerable<SubElement>> GetSubElements()
        {
            return await subElementRepository.GetSubElements();
        }

        public async Task<SubElement?> GetSubElement(Guid uid)
        {
            return await subElementRepository.GetSubElement(uid);
        }
    }
}
