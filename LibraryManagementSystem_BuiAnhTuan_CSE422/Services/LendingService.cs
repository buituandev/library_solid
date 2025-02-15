using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services
{
    public class LendingService(IReaderRepository readerRepository, IBookRepository bookRepository) : ILendingService
    {
        public IReaderRepository ReaderRepository = readerRepository;
        public IBookRepository BookRepository = bookRepository;

        public void BorrowBook(string readerId, string bookId)
        {
            var reader = ReaderRepository.GetReader(readerId);
            var book = BookRepository.GetBook(bookId);
            BookRepository.RemoveBook(book
        }

        public List<IBook> GetBorrowedBooks(string readerId)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(string readerId, string bookId)
        {
            throw new NotImplementedException();
        }
    }
}
