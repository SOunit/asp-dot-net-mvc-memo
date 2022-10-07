using asp_dot_net_mvc_demo.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_dot_net_mvc_demo.Data
{
    public class ApplicationDbContext : DbContext
    {
        // general setting for db-context
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // create table
        public DbSet<Record> Records { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
