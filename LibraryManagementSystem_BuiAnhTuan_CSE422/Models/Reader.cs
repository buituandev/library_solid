using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Models
{
    public class Reader : IReader
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<IBook> BorrowedBooks { get; set; }
        public bool CanBorrowMoreBooks()
        {
            return BorrowedBooks.Count < 4;
        }
    }
}
