namespace JewelryStore.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Jewel>? Jewels { get; set; }
    }
}
