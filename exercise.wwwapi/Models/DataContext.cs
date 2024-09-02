using exercise.wwwapi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace exercise.wwwapi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {


        }

        public DbSet<Product> Products { get; set; }


    }
}
