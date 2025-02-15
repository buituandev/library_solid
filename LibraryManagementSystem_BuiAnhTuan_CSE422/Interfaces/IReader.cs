namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IReader
    {
        string Id { get; set; }
        string Name { get; set; }
        List<IBook> BorrowedBooks { get; set; }
        
        string ToString();
    }
}
