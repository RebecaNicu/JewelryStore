using JewelryStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.Context
{
    public class JewelryStoreContext : IdentityDbContext<IdentityUser>
    {
        public JewelryStoreContext(DbContextOptions<JewelryStoreContext> options)
            : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Jewel> Jewels { get; set; }
        public DbSet<JewelCart> JewelCarts { get; set; }
        public DbSet<JewelOrder> JewelOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationship ManyToMany Jewel->Cart
            modelBuilder.Entity<JewelCart>()
                .HasKey(jc => new { jc.Id });
            modelBuilder.Entity<JewelCart>()
                .HasOne(jc => jc.Jewel)
                .WithMany(j => j.JewelCarts)
                .HasForeignKey(jc => jc.JewelId);
            modelBuilder.Entity<JewelCart>()
                .HasOne(jc => jc.Cart)
                .WithMany(c => c.JewelCarts)
                .HasForeignKey(jc => jc.CartId);

            //Relationship ManyToMany Jewel->Order
            modelBuilder.Entity<JewelOrder>()
                .HasKey(jc => new { jc.Id });
            modelBuilder.Entity<JewelOrder>()
                .HasOne(jc => jc.Jewel)
                .WithMany(j => j.JewelOrders)
                .HasForeignKey(jc => jc.JewelId);
            modelBuilder.Entity<JewelOrder>()
                .HasOne(jc => jc.Order)
                .WithMany(c => c.JewelOrders)
                .HasForeignKey(jc => jc.OrderId);

            modelBuilder.Entity<Jewel>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Jewels)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Jewel>()
              .HasOne(p => p.Brand)
              .WithMany(c => c.Jewels)
              .HasForeignKey(p => p.BrandId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
              .HasOne(r => r.Jewel)
              .WithMany(c => c.Reviews)
              .HasForeignKey(p => p.JewelId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
