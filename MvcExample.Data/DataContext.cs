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

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
