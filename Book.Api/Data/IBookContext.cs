using Microsoft.EntityFrameworkCore;
using BookClass = Book.Api.Entities.Book;

namespace Book.Api.Data
{
    public interface IBookContext
    {
        public DbSet<BookClass> Books { set; get; }
    }
}
