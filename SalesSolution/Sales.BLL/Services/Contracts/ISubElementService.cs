using Sales.DAL.Entities;

namespace Sales.BLL.Services.Contracts
{
    public interface ISubElementService
    {
        IEnumerable<SubElement> GetSubElements();
        IEnumerable<SubElement> GetSubElements(Guid windowId);
        SubElement? GetSubElement(Guid uid);
        SubElement AddSubElement(SubElement subElement);
        SubElement EditSubElement(SubElement subElement);
        bool DeleteSubElement(Guid uid);
    }
}
