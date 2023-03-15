namespace Sales.Api.Models
{
    public class SubElement : IBaseModel
    {
        public int Element { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Quantity { get; set; }
        public Guid ElementTypeId { get; set; }
        public Guid WindowId { get; set; }

        public Window Window { get; set; }
        public ElementType ElementType { get; set; }
    }
}
