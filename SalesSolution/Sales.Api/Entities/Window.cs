namespace Sales.Api.Entities
{
    public class Window : IBaseModel
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }

        public Order Order { get; set; }
        public IEnumerable<SubElement> SubElements { get; set; } = new List<SubElement>();
    }
}
