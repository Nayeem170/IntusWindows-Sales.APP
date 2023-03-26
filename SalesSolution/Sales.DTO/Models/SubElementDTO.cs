using System.ComponentModel.DataAnnotations;

namespace Sales.DTO.Models
{
    public class SubElementDTO : BaseDTO
    {
        public SubElementDTO()
        {
            UId = Guid.NewGuid();
        }
        public int Element { get; set; }
        [Required(ErrorMessage = "Please enter a sub elemnt width.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive width for the sub element.")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Please enter a sub elemnt height.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive height for the sub element.")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Please enter a sub elemnt quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive quantity for the sub element.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please enter a sub elemnt type.")]
        public Guid ElementTypeId { get; set; }
        public string? ElementTypeName { get; set; }
        [Required(ErrorMessage = "Please enter an elemnt window.")]
        public Guid WindowId { get; set; }
    }
}
