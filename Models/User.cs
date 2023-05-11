using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace JewelryStore.Models
{
    public class User : IdentityUser
    {
        public Cart? Cart { get; set; }
        public ICollection<Review> Reviews { get; } = new List<Review>();
        public string? UrlProfiePhoto { get; set; }
        public string? Address { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }


    }
}
