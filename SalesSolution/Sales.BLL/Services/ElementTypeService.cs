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

        public async Task<IEnumerable<ElementType>> GetElementTypes()
        {
            return await elementTypeRepository.GetElementTypes();
        }

        public async Task<ElementType?> GetElementType(Guid uid)
        {
            return await elementTypeRepository.GetElementType(uid);
        }
    }
}
