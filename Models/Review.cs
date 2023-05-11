using System.Reflection.Metadata;

namespace JewelryStore.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public float StarValue { get; set; }
        public Jewel? Jewel { get; set; }
        public int JewelId { get; set; }
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
