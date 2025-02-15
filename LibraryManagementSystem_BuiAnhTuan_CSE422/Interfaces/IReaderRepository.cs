namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IReaderRepository
    {
        void AddReader(IReader reader);
        void RemoveReader(IReader reader);
        IReader? GetReader(string readerId);
        List<IReader> GetAllReader();
        List<IBook> GetBorrowedBooks(string readerId);
        
    }
}
