using Microsoft.EntityFrameworkCore;
using MvcExample.Data.Entities;

namespace MvcExample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
