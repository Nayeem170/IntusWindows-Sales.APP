namespace Sales.DTO.Models
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            UId = new Guid();
        }
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public IEnumerable<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
    }
}
