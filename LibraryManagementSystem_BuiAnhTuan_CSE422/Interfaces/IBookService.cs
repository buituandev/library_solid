namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IBookService
    {
        void AddBook(string title, string author, string category, int quantity);
        void AddEBook(string title, string author, string category, int quantity, string format, string link);
        void AddMagazine(string title, string author, string category, int quantity, string topic, int issue);
        bool RemoveBook(string bookId);
        string GetBook(string bookId);
        string GetBookByTitle(string title);
        string GetBookByCategory(string category);
        bool UpdateBookQuantity(string bookId, int quantity);
        string ShowAllBooks();
    }
}
