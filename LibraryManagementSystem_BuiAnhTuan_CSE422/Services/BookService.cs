using System.Text;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        public void AddBook(string title, string author, string category, int quantity)
        {
            var book = new Book
            {
                Id = Guid.NewGuid().ToString().Replace("-", ""),
                Title = title,
                Author = author,
                Category = category,
                Quantity = quantity
            };
            bookRepository.AddBook(book);
        }

        public void AddEBook(string title, string author, string category, int quantity, string format, string link)
        {
            var book = new EBook
            {
                Id = Guid.NewGuid().ToString().Replace("-", ""),
                Title = title,
                Author = author,
                Category = category,
                Quantity = quantity,
                Format = format,
                Link = link
            };
            bookRepository.AddBook(book);
        }

        public void AddMagazine(string title, string author, string category, int quantity, string topic, int issue)
        {
            var book = new Magazine
            {
                Id = Guid.NewGuid().ToString().Replace("-", ""),
                Title = title,
                Author = author,
                Category = category,
                Quantity = quantity,
                Issue = issue,
                Topic = topic
            };
            bookRepository.AddBook(book);
        }

        public string GetBook(string bookId)
        {
            var book = bookRepository.GetBook(bookId);
            return book == null ? $"Message:{bookId} not found" : book.ToString();
        }

        public string GetBookByCategory(string category)
        {
            var stringBuilder = new StringBuilder();
            foreach (var book in bookRepository.GetBookByCategory(category))
            {
                stringBuilder.AppendLine(book.ToString());
            }

            return stringBuilder.Length == 0 ? "No books found" : stringBuilder.ToString();
        }

        public string GetBookByTitle(string title)
        {
            var stringBuilder = new StringBuilder();
            foreach (var book in bookRepository.GetBookByTitle(title))
            {
                stringBuilder.AppendLine(book.ToString());
            }

            return stringBuilder.Length == 0 ? "No books found" : stringBuilder.ToString();
        }

        public bool RemoveBook(string bookId)
        {
            var book = bookRepository.GetBook(bookId);
            if (book == null) return false;
            bookRepository.RemoveBook(book);
            return true;
        }

        public bool UpdateBookQuantity(string bookId, int quantity)
        {
            var book = bookRepository.GetBook(bookId);
            if (book == null) return false;
            bookRepository.UpdateBookQuantity(bookId, quantity);
            return true;
        }

        public bool IsBookAvailable(string bookId)
        {
            var book = bookRepository.GetBook(bookId);
            if (book == null) return false;
            return book.Quantity > 0;
        }

        public string ShowAllBooks()
        {
            var books = bookRepository.GetAllBooks();
            var stringBuilder = new StringBuilder();
            foreach (var book in books)
            {
                stringBuilder.AppendLine(book.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}