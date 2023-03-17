using Sales.DAL.Entities;
using Sales.DTO.Models;

namespace Sales.API.Extentions
{
    public static class DtoConversions
    {
        public static OrderDTO ConvertToDto(this Order order)
        {
            return new OrderDTO
            {
                UId = order.UId,
                Name = order.Name,
                State = order.State,
                Windows = order.Windows.ConvertToDto(),
            };
        }

        public static IEnumerable<OrderDTO> ConvertToDto(this IEnumerable<Order> orders)
        {
            return orders
                .OrderBy(order => order.CreatedAt)
                .Select(order => order.ConvertToDto());
        }

        public static WindowDTO ConvertToDto(this Window window)
        {
            return new WindowDTO
            {
                UId = window.UId,
                Name = window.Name,
                Quantity = window.Quantity,
                SubElements = window.SubElements.ConvertToDto()
            };
        }

        public static IEnumerable<WindowDTO> ConvertToDto(this IEnumerable<Window> windows)
        {
            return windows
                .OrderBy(window => window.CreatedAt)
                .Select(window => window.ConvertToDto());
        }

        public static SubElementDTO ConvertToDto(this SubElement subElement)
        {
            return new SubElementDTO
            {
                UId = subElement.UId,
                Quantity = subElement.Quantity,
                Element = subElement.Element,
                ElementTypeId = subElement.ElementTypeId,
                ElementTypeName = subElement.ElementType.Name,
                Height = subElement.Height,
                Width = subElement.Width
            };
        }

        public static IEnumerable<SubElementDTO> ConvertToDto(this IEnumerable<SubElement> subElements)
        {
            return subElements
                .OrderBy(subElement => subElement.Element)
                .Select(subElement => subElement.ConvertToDto());
        }

        public static ElementTypeDTO ConvertToDto(this ElementType elementType)
        {
            return new ElementTypeDTO
            {
                UId = elementType.UId,
                Name = elementType.Name
            };
        }

        public static IEnumerable<ElementTypeDTO> ConvertToDto(this IEnumerable<ElementType> elementTypes)
        {
            return elementTypes
                .Select(elementType => elementType.ConvertToDto());
        }
    }
}
