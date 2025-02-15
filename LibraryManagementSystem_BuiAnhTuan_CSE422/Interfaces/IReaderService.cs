namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IReaderService
    {
        void RegisterReader(string readerId, string readerName);
        string GetReaderDetails(string readerId);
        void UpdateReaderInfo(IReader reader);
    }
}
