using ASP_Test_01.Model;

namespace ASP_Test_01.Repository
{
    public interface IBookRepository
    {
        Book AddBook(Book book);
        int DeleteBook(int id);
        List<Book> GetBooks();
        Book UpdateBook(int id, Book bookData);
    }
}