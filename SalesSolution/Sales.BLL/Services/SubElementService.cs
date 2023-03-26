using Sales.BLL.Extentions;
using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;
using Sales.LIB.Extentions;

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

        public SubElement AddSubElement(SubElement subElement)
        {
            if (subElement == null)
            {
                throw new ArgumentNullException("Sub element can not be null");
            }

            subElement.SetElement()
                .VerifyHeight();

            return subElementRepository.Add(subElement);
        }

        public SubElement EditSubElement(SubElement subElement)
        {
            if (subElement == null)
            {
                throw new ArgumentNullException("Sub element can not be null");
            }

            var previousSubElement = subElementRepository.Get(subElement.UId);
            subElementRepository.Detach(previousSubElement);

            subElement = subElementRepository.Edit(subElement);
            subElementRepository.Detach(subElement);

            var previousHeight = previousSubElement.Height;
            var newHeight = subElement.Height;

            if (previousHeight != newHeight)
            {
                var windowSubElements = subElementRepository
                    .GetAll(subElement.WindowId);

                foreach (var element in windowSubElements)
                {
                    element.Height = newHeight;
                };

                subElementRepository.Edit(windowSubElements);
            }

            return subElement;
        }

        public bool DeleteSubElement(Guid uid)
        {
            var subElement = GetSubElement(uid);
            if (!subElement.IsNull())
            {
                return subElementRepository.Delete(subElement);
            }
            return false;
        }
    }
}
