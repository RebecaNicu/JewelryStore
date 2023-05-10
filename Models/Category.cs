namespace JewelryStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public List<Jewel>? Jewels { get; set; }
    }
}
