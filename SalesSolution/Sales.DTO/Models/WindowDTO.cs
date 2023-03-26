using System.ComponentModel.DataAnnotations;

namespace Sales.DTO.Models
{
    public class WindowDTO : BaseDTO
    {
        public WindowDTO()
        {
            UId = Guid.NewGuid();
        }

        [Required(ErrorMessage = "Please enter an window name.")]
        [MaxLength(30, ErrorMessage = "Please enter an window name with a maximum of 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an window quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive quantity for the window.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter an window order.")]
        public Guid OrderId { get; set; }

        public int? NumberOfSubElements { get; set; }
        public IEnumerable<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
