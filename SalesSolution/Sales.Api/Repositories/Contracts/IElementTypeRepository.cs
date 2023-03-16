using Sales.Api.Entities;

namespace Sales.Api.Repositories.Contracts
{
    public interface IElementTypeRepository
    {
        Task<IEnumerable<ElementType>> GetElementTypes();
        Task<ElementType?> GetElementType(Guid uid);
    }
}
