using Microsoft.EntityFrameworkCore;
using System;


namespace Data.Models
{
    public partial class ThePizzaDBContext : DbContext
    {
        public ThePizzaDBContext(DbContextOptions<ThePizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Topping> Topping { get; set; }

        // Unable to generate entity type for table 'dbo.ProductTopping'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThePizzaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<Topping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductTopping>()
                .HasKey(pt => new { pt.ProductID, pt.ToppingId });

            modelBuilder.Entity<ProductTopping
                >()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductToppings)
                .HasForeignKey(pt => pt.ProductID);



            modelBuilder.Entity<ProductTopping>()
           .HasOne(pt => pt.Topping)
           .WithMany(t => t.ProductToppings)
           .HasForeignKey(pt => pt.ToppingId);
        }
    }
}
