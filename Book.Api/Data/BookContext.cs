using BookClass = Book.Api.Entities.Book;
using Microsoft.EntityFrameworkCore;

namespace Book.Api.Data
{
    public class BookContext : DbContext, IBookContext
    {
        public BookContext(DbContextOptions options)
            : base(options) { }

        public DbSet<BookClass> Books { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<BookClass>()
                .HasData(
                    new BookClass { Id = Guid.NewGuid(), Name = "Bible" },
                    new BookClass { Id = Guid.NewGuid(), Name = "Where do camels belong?" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
