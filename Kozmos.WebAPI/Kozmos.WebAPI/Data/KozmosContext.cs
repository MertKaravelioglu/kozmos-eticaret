using Kozmos.WebAPI.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kozmos.WebAPI.Data
{
    public class KozmosContext:IdentityDbContext<ApplicationUser>
    {
        public readonly IHttpContextAccessor httpContextAccessor;
        public KozmosContext(DbContextOptions<KozmosContext> options, IHttpContextAccessor httpContextAccessor) :base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity => {

                entity.Property(e => e.PriceWithDiscount).HasColumnType("money");
                entity.Property(e => e.PriceWithoutDiscount).HasColumnType("money");
                

            });
            modelBuilder.Entity<Checkout>(entity => {

                entity.Property(e => e.TotalPrice).HasColumnType("money");
                


            });

            modelBuilder.Entity<Product>()
                .HasOne<Category>(p=>p.Category)
                .WithMany(p=>p.Products)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<CustomerMessage>()
                .HasOne<ApplicationUser>(p => p.ApplicationUser)
                .WithMany(p => p.CustomerMessages)
                .HasForeignKey(p => p.ApplicationUserId);

            modelBuilder.Entity<Checkout>()
                .HasOne<ApplicationUser>(p => p.ApplicationUser)
                .WithMany(p => p.Checkouts)
                .HasForeignKey(p => p.ApplicationUserId);
            modelBuilder.Entity<BasketItem>()
                .HasOne<Checkout>(p => p.Checkout)
                .WithMany(p => p.BasketItems)
                .HasForeignKey(p => p.CheckoutId);
                
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
        public DbSet<CustomerMessage> CustomerMessages { get; set; }
        public DbSet<ApplicationUserTokens> ApplicationUserTokens { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

    }
}
