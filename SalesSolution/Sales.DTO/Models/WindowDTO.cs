using System.ComponentModel.DataAnnotations;

namespace Sales.DTO.Models
{
    public class WindowDTO : BaseDTO
    {
        public WindowDTO()
        {
            UId = Guid.NewGuid();
        }

        [Required]
        [MaxLength(30, ErrorMessage = "Please enter an window name with a maximum of 30 characters.")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number for the window quantity.")]
        public int Quantity { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        public int? NumberOfSubElements { get; set; }
        public IEnumerable<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
