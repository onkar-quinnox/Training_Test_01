
using ASP_Test_01.Model;
using ASP_Test_01.Repository;
using Moq;

namespace TestAPI
{
    public class UnitTest1


    {
       

        public UnitTest1()
        {
            
        }

        

        [Fact]
        public void API_Repository_GetMethod_And_AddMethod_Test()
        {
            // Arrange
           
           var book = new Book()
            {
                ISBN = 100,
                Title = "A man called Ove",
                Author = "Fredrik Backman",
                Price = 499
            };
            var mockRepo = new Mock<IBookRepository>();
           var service = new BookRepository(); 

            mockRepo.Setup(r => r.AddBook(It.IsAny<Book>()))
                .Callback<Book>((b) => service.AddBook(b)); 

            mockRepo.Setup(r => r.GetBooks()).Returns(() => service.GetBooks());

            //Act
            mockRepo.Object.AddBook(book); 
            var result = mockRepo.Object.GetBooks(); 

            // Assert
            Assert.Single(result); 
            Assert.Equal(book, result[0]);
        }

        [Fact]
        public void API_Repository_DeleteMethod_Test()
        {


            int id = 6;
            // Arrange
            var book = new Book()
            {
                ISBN = 100,
                Title = "A man called Ove ooo",
                Author = "Fredrik Backman",
                Price = 499
            };
            var mockRepo = new Mock<IBookRepository>();
            var service = new BookRepository();

            //mockRepo.Setup(r => r.AddBook(It.IsAny<Book>()))
            //    .Callback<Book>((b) => service.AddBook(b));

            mockRepo.Setup(r => r.DeleteBook(id)).Returns(() => service.DeleteBook(id));

            //Act
          //  mockRepo.Object.AddBook(book);
            var res = mockRepo.Object.DeleteBook(id);

            //Assert
          
            if (id+1 == book.Id)
            {
                Assert.Equal(id, res);
            }
            else
            {
                Assert.Equal(-1, res);
            }

       }
        [Fact]
        public void API_Repository_UpdateMethod_Test()
        {
            int id = 8;
            // Arrange
            var book = new Book()
            {
                ISBN = 100,
                Title = "A man called Ove",
                Author = "Fredrik Backman",
                Price = 499
            };
            var Updatebook = new Book()
            {
                ISBN = 102,
                Title = "Rich data poor dad",
                Author = "RObbert Kyosaki",
                Price = 249
            };

            var mockRepo = new Mock<IBookRepository>();
            var service = new BookRepository();

            //mockRepo.Setup(r => r.AddBook(It.IsAny<Book>()))
            //    .Callback<Book>((b) => service.AddBook(b));

            mockRepo.Setup(r => r.UpdateBook(id,Updatebook)).Returns(() => service.UpdateBook(id,Updatebook));

            //Act
          //  mockRepo.Object.AddBook(book);
            var res = mockRepo.Object.UpdateBook(id, Updatebook);

            //Assert
            if (id + 1 != book.Id)
            {
                Assert.Null(res); ;
            }
            else
            {
                Assert.NotNull(res);
                Assert.Equal(Updatebook.ISBN, res.ISBN);
                Assert.Equal(Updatebook.Title, res.Title);
                Assert.Equal(Updatebook.Author, res.Author);
                Assert.Equal(Updatebook.Price, res.Price);
            }
           

            // Verify that the UpdateBook method was called once with the correct arguments
            mockRepo.Verify(r => r.UpdateBook(id, Updatebook), Times.Once());

        }
        }
}