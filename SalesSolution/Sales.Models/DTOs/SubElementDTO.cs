using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models.DTOs
{
    public class SubElementDTO
    {
        public Guid UId { get; set; }
        public int Element { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quantity { get; set; }
        public Guid ElementTypeId { get; set; }
        public string ElementTypeName { get; set; }
    }
}
