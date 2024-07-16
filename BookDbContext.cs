using Microsoft.EntityFrameworkCore;

namespace Lecture10_Gr2
{
    // book dbcontext
    public class BookDbContext : DbContext
    {
        public DbSet<Wigni> Wignebi { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> opts) : base(opts)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BooksDatabase");
        }
    

    }
}
