using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Models.DTOs
{
    public class WindowDTO
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
