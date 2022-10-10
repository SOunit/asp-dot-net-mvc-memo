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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonBook>().HasKey(pb => new
            {
                pb.PersonId,
                pb.BookId
            });

            modelBuilder.Entity<PersonBook>()
                .HasOne(pb => pb.Person)
                .WithMany(p => p.PersonsBooks)
                .HasForeignKey(pb => pb.PersonId);

            modelBuilder.Entity<PersonBook>()
                .HasOne(pb => pb.Book)
                .WithMany(b => b.PersonsBooks)
                .HasForeignKey(pb => pb.BookId);

            base.OnModelCreating(modelBuilder);
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

        // many to many relationship

        // person
        // already declared

        // book
        public DbSet<Book> Books { get; set; }

        // PersonBook
        public DbSet<PersonBook> PersonsBooks { get; set; }
    }
}
