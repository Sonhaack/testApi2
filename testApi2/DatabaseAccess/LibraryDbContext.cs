using Microsoft.EntityFrameworkCore;
using testApi2.Model;

namespace testApi2.DatabaseAccess
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Library.db");
        }
    }
}