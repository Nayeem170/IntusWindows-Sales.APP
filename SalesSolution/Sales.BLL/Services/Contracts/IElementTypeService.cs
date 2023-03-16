using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IElementTypeService
    {
        Task<IEnumerable<ElementType>> GetElementTypes();
        Task<ElementType?> GetElementType(Guid uid);
    }
}
