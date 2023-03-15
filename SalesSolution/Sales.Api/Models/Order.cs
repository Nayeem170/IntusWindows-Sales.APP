namespace Sales.Api.Models
{
    public class Order : IBaseModel
    {
        public string Name { get; set; }
        public string State { get; set; }

        public List<Window> Windows { get; set; }
    }
}
