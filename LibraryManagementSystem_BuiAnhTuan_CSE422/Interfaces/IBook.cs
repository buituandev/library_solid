namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IBook
    {
        string? Id { get; set; }
        string? Title { get; set; }
        string? Author { get; set; }
        string? Category { get; set; }
        int Quantity { get; set; }
        string ToString();
    }
}
