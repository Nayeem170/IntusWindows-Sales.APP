using System.ComponentModel.DataAnnotations;

namespace Sales.DAL.Entities
{
    public class Order : BaseModel
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(2)]
        [Required]
        public string State { get; set; }

        public IEnumerable<Window> Windows { get; set; } = new List<Window>();
    }
}
