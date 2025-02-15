namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IReaderService
    {
        void AddReader(string readerName);
        IReader? GetReader(string readerId);
        void RemoveReader(string readerId);
        string GetReaderDetails(string readerId);
        void UpdateReaderInfo(string name, string readerId);
        bool CanBorrowMoreBooks(string readerId);
        string ShowAllReaders();
    }
}
