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

        // 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // create table
        public DbSet<Record> Tasks { get; set; }
    }
}
