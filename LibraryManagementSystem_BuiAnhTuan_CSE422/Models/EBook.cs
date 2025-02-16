namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Models
{
    public class EBook : Book
    {
        public string? Format { get; init; }
        public string? Link { get; init; }
        
        public override string ToString()
        {
            return $"Id: {Id} - Title: {Title} - Author: {Author} - Category: {Category} - Quantity: {Quantity} - Format: {Format} - Link: {Link}";
        }
    }
}
