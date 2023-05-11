using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace JewelryStore.Models
{
    public class User : IdentityUser
    {
        public Cart? Cart { get; set; }
        public ICollection<Review> Reviews { get; } = new List<Review>();
        string? UrlProfiePhoto { get; set; }
        string? Address { get; set; }
        string? firstName { get; set; } 
        string? lastName { get; set; }
    }
}
