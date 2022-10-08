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

        // base crud?
        public DbSet<Record> Records { get; set; }

        // update multiple orders
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        // one to one relationship
        public DbSet<Person> Persons { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
