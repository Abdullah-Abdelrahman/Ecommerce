using Ecomerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ecomerce.ViewModels;


namespace Ecomerce.Data
{
    public class SystemContext : IdentityDbContext
    {

        public DbSet<Product> ProductList { get; set; }

        public DbSet<Block> Blocks { get; set; }
        public DbSet<Categoriy> Categorias { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<StyleSize> StyleSizes { get; set; }
        public DbSet<ProductCategoriy> ProductCategoriys { get; set; }
        public DbSet<ProductSize> productSizes { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Customer> customers { get; set; }
        public SystemContext()
        {
            // Parameterless constructor for design-time
        }

        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
        }
        // we need the options to creat the coniction
   //     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   //     {
   //         base.OnConfiguring(optionsBuilder);
			   
			//// throw the type of dbms and the conection string
			//optionsBuilder.UseSqlServer("data source=DESKTOP-30J4B23\\SQLEXPRESS;initial catalog=SHOSE_ECOMERCE;TrustServerCertificate=True;trusted_connection=true");

   //     }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<ProductCategoriy>()
                .HasKey(e => new { e.ProductId, e.CategoriyId });
            modelBuilder.Entity<ProductSize>()
              .HasKey(e => new { e.ProductId, e.SizeId });
            modelBuilder.Entity<StyleSize>()
              .HasKey(e => new { e.StyleId, e.SizeId });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Ecomerce.ViewModels.RegisterAccountViewModel> RegisterAccountViewModel { get; set; } = default!;
        public DbSet<Ecomerce.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<Ecomerce.ViewModels.RoleViewModel> RoleViewModel { get; set; } = default!;
    }
}
