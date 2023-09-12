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


            int id = 1;
            // Arrange
            var book = new Book()
            {
                ISBN = 100,
                Title = "A man called Ove",
                Author = "Fredrik ONkar Backman",
                Price = 499
            };
            var mockRepo = new Mock<IBookRepository>();
            var service = new BookRepository();

            mockRepo.Setup(r => r.AddBook(It.IsAny<Book>()))
                .Callback<Book>((b) => service.AddBook(b));

            mockRepo.Setup(r => r.DeleteBook(id)).Returns(() => service.DeleteBook(id));

            //Act
            mockRepo.Object.AddBook(book);
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

    }
}