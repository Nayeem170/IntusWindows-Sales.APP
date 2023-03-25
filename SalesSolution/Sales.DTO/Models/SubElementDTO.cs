namespace Sales.DTO.Models
{
    public class SubElementDTO : BaseDTO
    {
        public int Element { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quantity { get; set; }
        public Guid ElementTypeId { get; set; }
        public string ElementTypeName { get; set; }
    }
}
