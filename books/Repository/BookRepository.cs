using books.DbContexts;
using books.Model;

namespace books.Repository
{
    public class BookRepository : IBooksRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void DeleteBook(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            _dbContext.Books.Remove(book);
            Save();
        }
        
        public Book GetBookById(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.ToList();
        }

        public void InsertBook(Book book)
        {
            _dbContext.Add(book);
            Save();
        }

        public void UpdateBook(Book book)
        {
            _dbContext.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();

        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
