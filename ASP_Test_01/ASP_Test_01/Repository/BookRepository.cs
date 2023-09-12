using ASP_Test_01.Model;

namespace ASP_Test_01.Repository
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new  List<Book>();

        public Book AddBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public List<Book> GetBooks()
        {

            return books;

        }

        public int DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return -1;
            }
            else
            {
                books.Remove(book);
                return id;
            }
        }

        public Book UpdateBook(int id, Book bookData)
        {
            var book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return book;
            }
            else
            {
                book.Author = bookData.Author;
                book.Title = bookData.Title;
                book.ISBN = bookData.ISBN;
                book.Price = bookData.Price;

                return book;
            }

        }
    }
}
