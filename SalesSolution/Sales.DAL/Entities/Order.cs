namespace Sales.DAL.Entities
{
    public class Order : IBaseModel
    {
        public string Name { get; set; }
        public string State { get; set; }

        public IEnumerable<Window> Windows { get; set; } = new List<Window>();
    }
}
