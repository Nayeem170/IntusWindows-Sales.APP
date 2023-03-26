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
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt
            };
        }

        public static IEnumerable<OrderDTO> ConvertToDto(this IEnumerable<Order> orders)
        {
            return orders
                .OrderByDescending(order => order.CreatedAt)
                .Select(order => order.ConvertToDto());
        }

        public static WindowDTO ConvertToDto(this Window window)
        {
            return new WindowDTO
            {
                UId = window.UId,
                Name = window.Name,
                Quantity = window.Quantity,
                NumberOfSubElements = window.SubElements?.Sum(subElement => subElement.Quantity),
                SubElements = window.SubElements.ConvertToDto(),
                CreatedAt = window.CreatedAt,
                UpdatedAt = window.UpdatedAt,
                OrderId = window.OrderId,
            };
        }

        public static IEnumerable<WindowDTO> ConvertToDto(this IEnumerable<Window> windows)
        {
            return windows
                .OrderByDescending(window => window.CreatedAt)
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
                ElementTypeName = subElement.ElementType?.Name,
                Height = subElement.Height,
                Width = subElement.Width,
                CreatedAt = subElement.CreatedAt,
                UpdatedAt = subElement.UpdatedAt
            };
        }

        public static IEnumerable<SubElementDTO> ConvertToDto(this IEnumerable<SubElement> subElements)
        {
            return subElements
                .OrderByDescending(subElement => subElement.Element)
                .Select(subElement => subElement.ConvertToDto());
        }

        public static ElementTypeDTO ConvertToDto(this ElementType elementType)
        {
            return new ElementTypeDTO
            {
                UId = elementType.UId,
                Name = elementType.Name,
                CreatedAt = elementType.CreatedAt,
                UpdatedAt = elementType.UpdatedAt
            };
        }

        public static IEnumerable<ElementTypeDTO> ConvertToDto(this IEnumerable<ElementType> elementTypes)
        {
            return elementTypes
                .Select(elementType => elementType.ConvertToDto());
        }

        public static Order ConvertToModel(this OrderDTO orderDTO)
        {
            return new Order
            {
                UId = orderDTO.UId,
                Name = orderDTO.Name,
                State = orderDTO.State,
                Windows = orderDTO.Windows.ConvertToModel(),
                CreatedAt = orderDTO.CreatedAt,
                UpdatedAt = orderDTO.UpdatedAt
            };
        }

        public static IEnumerable<Window> ConvertToModel(this IEnumerable<WindowDTO> windowDTOs)
        {
            return windowDTOs
                .Select(windowDTO => windowDTO.ConvertToModel());
        }

        public static Window ConvertToModel(this WindowDTO windowDTO)
        {
            return new Window
            {
                UId = windowDTO.UId,
                Name = windowDTO.Name,
                Quantity = windowDTO.Quantity,
                SubElements = windowDTO.SubElements.ConvertToModel(),
                CreatedAt = windowDTO.CreatedAt,
                UpdatedAt = windowDTO.UpdatedAt,
                OrderId = windowDTO.OrderId
            };
        }

        public static IEnumerable<SubElement> ConvertToModel(this IEnumerable<SubElementDTO> subElementDTOs)
        {
            return subElementDTOs
                .Select(subElementDTO => subElementDTO.ConvertToModel());
        }

        public static SubElement ConvertToModel(this SubElementDTO subElementDTO)
        {
            return new SubElement
            {
                UId = subElementDTO.UId,
                Quantity = subElementDTO.Quantity,
                Element = subElementDTO.Element,
                ElementTypeId = subElementDTO.ElementTypeId,
                Height = subElementDTO.Height,
                Width = subElementDTO.Width,
                CreatedAt = subElementDTO.CreatedAt,
                UpdatedAt = subElementDTO.UpdatedAt
            };
        }
    }
}
