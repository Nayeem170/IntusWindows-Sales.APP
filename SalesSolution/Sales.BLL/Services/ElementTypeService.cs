using Sales.BLL.Services.Contracts;
using Sales.DAL.Entities;
using Sales.DAL.Repositories.Contracts;

namespace Sales.BLL.Services
{
    public class ElementTypeService : IElementTypeService
    {
        private readonly IElementTypeRepository elementTypeRepository;

        public ElementTypeService(IElementTypeRepository elementTypeRepository)
        {
            this.elementTypeRepository = elementTypeRepository;
        }

        public IEnumerable<ElementType> GetElementTypes()
        {
            return elementTypeRepository.GetAll();
        }

        public ElementType? GetElementType(Guid uid)
        {
            return elementTypeRepository.Get(uid);
        }
    }
}
