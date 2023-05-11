namespace JewelryStore.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public float TotalAmount { get; set; }
        public List<JewelCart>? JewelCarts { get; set; }
        public List<Order>? Orders { get; set; }
        public User? User { get; set; }   
        public string? UserId { get; set; }
    }
}
