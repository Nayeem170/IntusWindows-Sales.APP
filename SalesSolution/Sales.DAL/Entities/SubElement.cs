using System.ComponentModel.DataAnnotations;

namespace Sales.DAL.Entities
{
    public class SubElement : BaseModel
    {
        public int Element { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Width { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Height { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public Guid ElementTypeId { get; set; }
        [Required]
        public Guid WindowId { get; set; }

        public Window Window { get; set; }
        public ElementType ElementType { get; set; }
    }
}
