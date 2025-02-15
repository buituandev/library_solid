using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Database;

public static class Data
{
    public static readonly List<IBook> Books;
    public static readonly List<IReader> Readers;
    public static readonly List<ReportRecord> Records = [];

    static Data()
    {
        Books =
        [
            new Book
            {
                Id = "1", Title = "Harry Potter", Author = "J.K. Rowling", Category = "Fantasy", Quantity = 10
            },
            new Book
            {
                Id = "2", Title = "The Da Vinci Code", Author = "Dan Brown", Category = "Mystery", Quantity = 5
            },
            new Magazine
            {
                Id = "3", Title = "National Geographic", Author = "National Geographic Society", Category = "Science",
                Quantity = 3, Topic = "Science", Issue = 1
            },
            new Magazine
            {
                Id = "4", Title = "Time", Author = "Time", Category = "News", Quantity = 2, Topic = "News", Issue = 2
            },
            new Book
            {
                Id = "5", Title = "The Alchemist", Author = "Paulo Coelho", Category = "Fantasy", Quantity = 7
            },
            new Book
            {
                Id = "6", Title = "The Little Prince", Author = "Antoine de Saint/Exupéry", Category = "Fantasy",
                Quantity = 6
            },
            new EBook
            {
                Id = "7", Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Category = "Fiction",
                Quantity = 4, Format = "PDF"
            },
            new EBook
            {
                Id = "8", Title = "The Catcher in the Rye", Author = "J.D. Salinger", Category = "Fiction",
                Quantity = 3, Format = "EPUB"
            },
            new EBook
            {
                Id = "9", Title = "1984", Author = "George Orwell", Category = "Fiction", Quantity = 2, Format = "MOBI"
            }
        ];
        
        Readers =
        [
            new Reader
            {
                Id = "1", Name = "John Doe", BorrowedBooks = [Books[0], Books[1]]
            },
            new Reader
            {
                Id = "2", Name = "Jane Doe", BorrowedBooks = []
            }
        ];
    }
}