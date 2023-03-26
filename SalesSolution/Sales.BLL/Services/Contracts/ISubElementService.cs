using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface ISubElementService
    {
        IEnumerable<SubElement> GetSubElements();
        IEnumerable<SubElement> GetSubElements(Guid windowId);
        SubElement? GetSubElement(Guid uid);
    }
}
