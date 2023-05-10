namespace JewelryStore.Models
{
    public class JewelCart
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int JewelId { get; set;} 
        public Cart? Cart { get; set; }
        public Jewel? Jewel { get; set; }
    }
}
