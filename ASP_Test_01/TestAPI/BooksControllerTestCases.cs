using ASP_Test_01.Controllers;
using ASP_Test_01.Model;
using ASP_Test_01.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI
{
    public class BooksControllerTestCases
    {

        public BooksControllerTestCases()
        {

        }

        [Fact]
        public async Task GetAllBooks_ReturnsOkResultWithBooks()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var booksController = new BooksController(mockBookRepository.Object);

            var expectedBooks = new List<Book>
        {
            new Book { ISBN = 1, Title = "Book 1", Author = "Author 1", Price = 109 },
            new Book { ISBN = 2, Title = "Book 2", Author = "Author 2", Price = 899 }

        };

            mockBookRepository.Setup(repo => repo.GetBooks()).Returns(expectedBooks);

            // Act
            var result = await booksController.GetAllBooks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);

            Assert.Equal(expectedBooks.Count, model.Count());

        }

        [Fact]
        public async Task AddBook_ReturnsCreatedResultWithBook()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var booksController = new BooksController(mockBookRepository.Object);

            var newBook = new Book
            {
                ISBN = 3,
                Title = "New Book",
                Author = "New Author",
                Price = 158
            };

            var addedBook = new Book
            {

                ISBN = newBook.ISBN,
                Title = newBook.Title,
                Author = newBook.Author,
                Price = newBook.Price
            };

            mockBookRepository.Setup(repo => repo.AddBook(newBook)).Returns(addedBook);

            // Act
            var result = await booksController.AddBook(newBook);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            var model = Assert.IsType<Book>(createdResult.Value);

            Assert.Equal(addedBook.Id.ToString(), createdResult.Location);
            Assert.Equal(addedBook, model);
        }
        [Fact]
        public async Task DeleteRecord_ExistingBook_ReturnsOkResult()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var booksController = new BooksController(mockBookRepository.Object);

            int existingBookId = 1;

            mockBookRepository.Setup(repo => repo.DeleteBook(existingBookId)).Returns(existingBookId);

            // Act
            var result = await booksController.DeleteRecord(existingBookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseValue = Assert.IsType<int>(okResult.Value);

            Assert.Equal(existingBookId, responseValue);
        }
        [Fact]
        public async Task DeleteRecord_NonExistingBook_ReturnsNotFoundResult()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var booksController = new BooksController(mockBookRepository.Object);

            int nonExistingBookId = 999; 

            mockBookRepository.Setup(repo => repo.DeleteBook(nonExistingBookId)).Returns(-1);

            // Act
            var result = await booksController.DeleteRecord(nonExistingBookId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var responseValue = Assert.IsType<string>(notFoundResult.Value);

            Assert.Equal("Record not found", responseValue);

        }
        [Fact]
        public async Task UpdateRecord_ExistingBook_ReturnsOkResult()
        {
            // Arrange
            var mockBookRepository = new Mock<IBookRepository>();
            var booksController = new BooksController(mockBookRepository.Object);
            var newBook = new Book
            {
                ISBN = 3,
                Title = "New Book",
                Author = "New Author",
                Price = 158
            };
            int existingBookId = 3;

            mockBookRepository.Setup(repo => repo.UpdateBook(existingBookId, newBook)).Returns(newBook);

            // Act
            var result = await booksController.UpdateBook(newBook, existingBookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var responseValue = Assert.IsType<Book>(okResult.Value);

            // You can assert the properties of the updated book if needed.
            Assert.Equal(existingBookId, responseValue.ISBN);
            Assert.Equal(newBook.Title, responseValue.Title);
            Assert.Equal(newBook.Author, responseValue.Author);
            Assert.Equal(newBook.Price, responseValue.Price);
        }
       
    }
}
