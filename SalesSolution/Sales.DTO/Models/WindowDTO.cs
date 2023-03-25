namespace Sales.DTO.Models
{
    public class WindowDTO : BaseDTO
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int? NumberOfSubElements { get; set; }
        public IEnumerable<SubElementDTO> SubElements { get; set; } = new List<SubElementDTO>();
    }
}
