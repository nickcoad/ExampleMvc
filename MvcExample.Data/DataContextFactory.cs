using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MvcExample.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseNpgsql("server=localhost;database=cqrs_example;username=postgres;password=password").Options;
            var context = new DataContext(options);

            return context;
        }
    }
}
