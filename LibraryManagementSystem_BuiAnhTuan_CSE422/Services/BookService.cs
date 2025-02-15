using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        public IBookRepository BookRepository = bookRepository;

        public void AddBook(IBook book)
        {
            bookRepository.AddBook(book);
        }

        public IBook? GetBook(string bookId)
        {
            var book = bookRepository.GetBook(bookId);
            return book;
        }

        public List<IBook> GetBookByAuthor(string author)
        {
            return bookRepository.GetBookByAuthor(author);
        }

        public List<IBook> GetBookByTitle(string title)
        {
            var books = bookRepository.GetBookByTitle(title);
            return books;
        }

        public bool RemoveBook(string bookId)
        {
            var book = bookRepository.GetBook(bookId);
            if (book != null)
            {
                bookRepository.RemoveBook(book);
                return true;
            }
            return false;
        }

        public bool UpdateBookQuantity(string bookId, int quantity)
        {
            var book = bookRepository.GetBook(bookId);
            if (book != null)
            {
                bookRepository.UpdateBookQuantity(bookId, quantity);
                return true;
            }
            return false;
        }
    }
}
