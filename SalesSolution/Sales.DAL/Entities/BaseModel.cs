using System.ComponentModel.DataAnnotations;

namespace Sales.DAL.Entities
{
    public class IBaseModel
    {
        [Key]
        public Guid UId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
