namespace Sales.Api.Models
{
    public class Window : IBaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
        public List<SubElement> SubElements { get; set; }
    }
}
