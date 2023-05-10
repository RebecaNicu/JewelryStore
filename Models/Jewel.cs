namespace JewelryStore.Models
{
    public class Jewel
    {
        public int? JewelId { get; set; }
        public string? JewelName { get; set; }
        public string? Details { get; set; }
        public float? Price { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public Brand? Brand { get; set; }
        public int BrandId { get; set; }
        public List<JewelCart>? JewelCarts { get; set; }
        public List<JewelOrder>? JewelOrders { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}
