using Sales.DAL.Entities;

namespace Sales.DAL.Repositories.Contracts
{
    public interface IElementTypeRepository
    {
        Task<IEnumerable<ElementType>> GetElementTypes();
        Task<ElementType?> GetElementType(Guid uid);
    }
}
