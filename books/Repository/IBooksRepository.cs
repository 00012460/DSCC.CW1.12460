using books.Model;

namespace books.Repository
{
    public interface IBooksRepository
    {
        void InsertBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        Book GetBookById(int bookId);
        IEnumerable<Book> GetBooks();
    }
}
