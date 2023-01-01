using Microsoft.EntityFrameworkCore;
using ShortUrlApi.Model;

namespace ShortUrlApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Link> Links { get; set; }
        public DbSet<Account> Accounts { get; set; }


    }
}
