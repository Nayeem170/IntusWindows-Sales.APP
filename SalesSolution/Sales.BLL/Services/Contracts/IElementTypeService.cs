using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface IElementTypeService
    {
        IEnumerable<ElementType> GetElementTypes();
        ElementType? GetElementType(Guid uid);
    }
}
