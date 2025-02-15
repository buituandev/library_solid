namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Models
{
    public class EBook : Book
    {
        public string Format { get; set; }
        public string Link { get; set; }
        
        public override string ToString()
        {
            return $"Id: {Id} - Title: {Title} - Author: {Author} - Category: {Category} - Quantity: {Quantity} - Format: {Format} - Link: {Link}";
        }
    }
}
