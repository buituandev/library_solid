using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Models
{
    public class Book : IBook
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        public void UpdateQuantity(int quantity)
        {
            Quantity += quantity;
        }
    }
}
