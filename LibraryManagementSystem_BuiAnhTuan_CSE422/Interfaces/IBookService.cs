namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IBookService
    {
        void AddBook(IBook book);
        bool RemoveBook(string bookId);
        IBook? GetBook(string bookId);
        List<IBook> GetBookByTitle(string title);
        List<IBook> GetBookByAuthor(string author);
        bool UpdateBookQuantity(string bookId, int quantity);
    }
}
