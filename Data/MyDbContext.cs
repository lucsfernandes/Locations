using Locations.Data.Config;
using Locations.Models;
using Microsoft.EntityFrameworkCore;

namespace Locations.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<SearchAddress> SearchAddress { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fará a conexão com o DB que está referenciado no AddressConfiguration
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new SearchAddressConfiguration());
        }
    }
}
