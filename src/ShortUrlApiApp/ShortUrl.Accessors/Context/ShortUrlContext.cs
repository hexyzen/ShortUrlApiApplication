using Microsoft.EntityFrameworkCore;
using ShortUrl.Accessors.Entities;


namespace ShortUrl.Accessors.Context
{
    public class ShortUrlContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Url> Urls { get; set; } = null!;
      
        public ShortUrlContext()
        {

        }
        public ShortUrlContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=shorturlapidb;trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                   .HasMaxLength(40)
                   .IsUnicode(false);
            });

        }
    }
}
