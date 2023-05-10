namespace JewelryStore.Models
{
    public class JewelOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int JewelId { get; set; }
        public Order? Order { get; set; }
        public Jewel? Jewel { get; set; }
    }
}
