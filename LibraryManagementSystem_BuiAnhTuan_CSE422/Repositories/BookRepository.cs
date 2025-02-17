using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories
{
    public class BookRepository(List<IBook> books) : IBookRepository
    {
        public void AddBook(IBook book)
        {
            books.Add(book);
        }

        public IBook? GetBook(string bookId)
        {
            return (from book in books where book.Id == bookId select book).FirstOrDefault();
        }

        public List<IBook> GetBookByCategory(string category)
        {
            return books.Where(book => book.Category == category).ToList();
        }

        public List<IBook> GetBookByTitle(string title)
        {
            return books.Where(book => book.Title == title).ToList();
        }

        public void RemoveBook(IBook book)
        {
            books.Remove(book);
        }

        public void UpdateBookQuantity(string bookId, int quantity)
        {
            books.FindAll(book => book.Id == bookId).ForEach(book => book.Quantity = quantity);
        }

        public List<IBook> GetAllBooks()
        {
            return books;
        }
    }
}