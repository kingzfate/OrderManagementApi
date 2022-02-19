using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    /// <summary>
    /// Main database context
    /// </summary>
    public class MainContext : DbContext
    {
        /// <summary>
        /// ctor
        /// </summary>
        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Postamat> Postamates { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}