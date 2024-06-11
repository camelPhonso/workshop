using Book.Api.Controllers;
using Book.Api.Data;
using Moq;
using Moq.EntityFrameworkCore;
using BookClass = Book.Api.Entities.Book;

namespace Book.Api.Tests.Controllers
{
    public class BookControllerTests
    {
        private readonly BookController _controller;

        public BookControllerTests() // The interface was being passed here as an argument - that's not de-coupling now is it ?!?!
        {
            var fakeData = new List<BookClass>
            {
                new BookClass { Id = Guid.NewGuid(), Name = "Fake Book 1" },
                new BookClass { Id = Guid.NewGuid(), Name = "Fake Book 2" }
            }.AsQueryable();

            var _context = new Mock<IBookContext>();
            _context.Setup(db => db.Books).ReturnsDbSet(fakeData);

            _controller = new BookController(_context.Object);
        }

        [Fact]
        public void GetAllBooks_Returns_Entire_List()
        {
            // Arrange


            // Act
            var expected = new List<BookClass>
            {
                new BookClass { Id = Guid.NewGuid(), Name = "Fake Book 1" },
                new BookClass { Id = Guid.NewGuid(), Name = "Fake Book 2" }
            }.AsQueryable();

            var result = _controller.GetAllBooks().ToList();

            // Assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public void GetSingleBook_Returns_Target_Book()
        {
            var expected = new BookClass { Id = Guid.NewGuid(), Name = "Fake Book 1" };

            var result = _controller.GetSingleBook("Fake Book 1");

            Assert.Equivalent(expected, result);
        }
    }
}
