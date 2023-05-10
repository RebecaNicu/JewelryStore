namespace JewelryStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public List<JewelCart>? JewelCarts { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
