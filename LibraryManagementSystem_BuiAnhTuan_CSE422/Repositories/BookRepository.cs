using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories
{
    public class BookRepository(List<IBook> books) : IBookRepository
    {
        public List<IBook> Books = books;

        public void AddBook(IBook book)
        {
            Books.Add(book);
        }

        public IBook? GetBook(string bookId)
        {
            return (from book in Books where book.Id == bookId select book).FirstOrDefault();
        }

        public List<IBook> GetBookByAuthor(string author)
        {
            return Books.Where(book => book.Author == author).ToList();
        }

        public List<IBook> GetBookByTitle(string title)
        {
            return Books.Where(book => book.Title == title).ToList();
        }

        public void RemoveBook(IBook book)
        {
            Books.Remove(book);
        }

        public void UpdateBookQuantity(string bookId, int quantity)
        {
            Books.FindAll(book => book.Id == bookId).ForEach(book => book.Quantity = quantity);
        }

        public List<IBook> GetAllBooks()
        {
            return Books;
        }
    }
}