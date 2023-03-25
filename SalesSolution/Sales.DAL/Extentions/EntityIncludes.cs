using Microsoft.EntityFrameworkCore;
using Sales.DAL.Entities;

namespace Sales.DAL.Extentions
{
    public static class EntityIncludes
    {
        public static IQueryable<Order> IncludeAll(this IQueryable<Order> orders)
        {
            return orders
                .Include(order => order.Windows)
                .ThenInclude(window => window.SubElements)
                .ThenInclude(subElement => subElement.ElementType)
                .AsQueryable();
        }

        public static IQueryable<Window> IncludeAll(this IQueryable<Window> windows)
        {
            return windows
                .Include(window => window.SubElements)
                .ThenInclude(subElement => subElement.ElementType)
                .AsQueryable();
        }

        public static IQueryable<Window> IncludeSubElement(this IQueryable<Window> windows)
        {
            return windows
                .Include(window => window.SubElements)
                .AsQueryable();
        }

        public static IQueryable<SubElement> IncludeAll(this IQueryable<SubElement> subElements)
        {
            return subElements
                .Include(subElement => subElement.ElementType)
                .AsQueryable();
        }
    }
}
