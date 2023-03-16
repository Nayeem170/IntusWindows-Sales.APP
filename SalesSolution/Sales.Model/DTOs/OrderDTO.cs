namespace Sales.Model.DTOs
{
    public class OrderDTO
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public IEnumerable<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
    }
}
