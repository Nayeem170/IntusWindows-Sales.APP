namespace Sales.DTO.Models
{
    public class WindowDTO
    {
        public Guid UId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
