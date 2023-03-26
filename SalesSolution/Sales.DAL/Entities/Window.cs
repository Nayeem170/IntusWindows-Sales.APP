using System.ComponentModel.DataAnnotations;

namespace Sales.DAL.Entities
{
    public class Window : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
        public IEnumerable<SubElement> SubElements { get; set; } = new List<SubElement>();
    }
}
