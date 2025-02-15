namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface ILendingService
    {
        string BorrowBook(string readerId, string bookId);
        string ReturnBook(string readerId, string bookId);
        List<IBook> GetBorrowedBooks(string readerId);
    }
}
