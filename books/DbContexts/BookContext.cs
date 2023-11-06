using books.Model;
using Microsoft.EntityFrameworkCore;

namespace books.DbContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

    }
}
