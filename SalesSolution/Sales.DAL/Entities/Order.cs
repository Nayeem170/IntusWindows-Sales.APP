using System.ComponentModel.DataAnnotations;

namespace Sales.DAL.Entities
{
    public class Order : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, MinimumLength = 2)]
        public string State { get; set; }

        public IEnumerable<Window> Windows { get; set; } = new List<Window>();
    }
}
