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
            foreach (var book in from book in Books
                                 where book.Id == bookId
                                 select book)
            {
                return book;
            }
            return null;
        }

        public List<IBook> GetBookByAuthor(string author)
        {
            List<IBook> booksByAuthor =
            [
                .. from book in Books
                                     where book.Author.Equals(author)
                                     select book,
            ];
            return booksByAuthor;
        }

        public List<IBook> GetBookByTitle(string title)
        {
            List<IBook> booksByAuthor =
            [
                .. from book in Books
                                     where book.Title.Equals(title)
                                     select book,
            ];
            return booksByAuthor;
        }

        public void RemoveBook(IBook book)
        {
            Books.Remove(book);
        }

        public void UpdateBookQuantity(string bookId, int quantity)
        {
            Books.FindAll(book => book.Id == bookId).ForEach(book => book.Quantity = quantity);
        }
    }
}
