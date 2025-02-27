﻿namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces
{
    public interface IBookRepository
    {
        void AddBook(IBook book);
        void RemoveBook(IBook book);
        IBook? GetBook(string bookId);
        List<IBook> GetBookByTitle(string title);
        List<IBook> GetBookByCategory(string category);
        void UpdateBookQuantity(string bookId, int quantity);
        List<IBook> GetAllBooks();
    }
}
