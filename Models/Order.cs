namespace JewelryStore.Models
{ 
    public class Order
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? BillingAddress { get; set; }
        public float? TotalAmount { get; set; }
        public string? DeliveryAddress { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? Details { get; set; }
        public Cart? Cart { get; set; }
        public int CartId { get; set; }
        public ICollection<JewelOrder>? JewelOrders { get; set; }
    }
}
