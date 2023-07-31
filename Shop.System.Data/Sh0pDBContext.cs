using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopSystem.Data.Models;

namespace Shop.System.Data
{
    public class Sh0pDBContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
           public Sh0pDBContext(DbContextOptions<Sh0pDBContext> options)
            : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Cart> Carts { get; set; }

    public DbSet<Bill> Bills { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<BillsClients> BillsClients { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<BillsClients>()
            .HasKey(k => new
            {
                k.ClientId,
                k.BillId
            });

        //builder.Entity<Bill>()
        //    .HasOne(h => h.Cart)
        //    .WithMany(b => b.Bills)
        //    .HasForeignKey(b => b.CartId)
        //    .OnDelete(DeleteBehavior.ClientCascade);

        //builder.Entity<Bill>()
        //    .HasOne(h => h.User)
        //    .WithMany(a => a.Bills)
        //    .HasForeignKey(h => h.UserId)
        //    .OnDelete(DeleteBehavior.ClientCascade);


        builder.Entity<Product>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

        builder.Entity<Product>()
            .Property(p => p.IsActive)
            .HasDefaultValue(false);

        builder.Entity<Category>()
            .Property(p => p.IsActive)
            .HasDefaultValue(false);

        builder.Entity<Cart>()
            .Property(p => p.IsActive)
            .HasDefaultValue(false);

        base.OnModelCreating(builder);
    }
}
}
