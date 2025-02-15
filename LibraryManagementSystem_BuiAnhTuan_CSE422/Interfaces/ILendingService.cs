namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface ILendingService
    {
        void BorrowBook(string readerId, string bookId);
        void ReturnBook(string readerId, string bookId);
        List<IBook> GetBorrowedBooks(string readerId);
    }
}
