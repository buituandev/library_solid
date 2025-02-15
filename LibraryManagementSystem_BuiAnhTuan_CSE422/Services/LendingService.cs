using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services
{
    public class LendingService(IBookRepository bookRepository, IReaderRepository readerRepository, ReaderService readerService, BookService bookService, ReportService reportService) : ILendingService
    {
        
        public string BorrowBook(string readerId, string bookId)
        {
            var reader = readerRepository.GetReader(readerId);
            var book = bookRepository.GetBook(bookId);
            if (reader == null || book == null)
            {
                return "Reader or book not found";
            }

            if (!readerService.CanBorrowMoreBooks(reader.Id))
            {
                return "Reader cannot borrow more books";
            }

            if (!bookService.IsBookAvailable(book.Id)) return "Book is not available";
            reader.BorrowedBooks.Add(book);
            bookService.UpdateBookQuantity(book.Id, book.Quantity - 1);
            reportService.AddReportTypeBorrow(reader.Id, book.Id);
            return "Book borrowed successfully";

        }

        public List<IBook> GetBorrowedBooks(string readerId)
        {
            var reader = readerRepository.GetReader(readerId);
            return reader == null ? [] : reader.BorrowedBooks;
        }

        public string ReturnBook(string readerId, string bookId)
        {
            var reader = readerRepository.GetReader(readerId);
            var book = bookRepository.GetBook(bookId);
            if (reader == null || book == null)
            {
                return "Reader or book not found";
            }

            if (!reader.BorrowedBooks.Contains(book))
            {
                return "Reader did not borrow this book";
            }

            reader.BorrowedBooks.Remove(book);
            bookService.UpdateBookQuantity(book.Id, book.Quantity + 1);
            reportService.AddReportTypeReturn(reader.Id, book.Id);
            return "Book returned successfully";
        }
    }
}
