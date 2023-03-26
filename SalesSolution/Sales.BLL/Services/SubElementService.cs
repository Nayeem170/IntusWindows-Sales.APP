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
        public IEnumerable<SubElement> GetSubElements()
        {
            return subElementRepository.GetAll();
        }

        public IEnumerable<SubElement> GetSubElements(Guid windowId)
        {
            return subElementRepository.GetAll(windowId);
        }

        public SubElement? GetSubElement(Guid windowId)
        {
            return subElementRepository.Get(windowId);
        }
    }
}
