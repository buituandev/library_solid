using System.Text;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services;

public class ReportService(IBookRepository bookRepository, IReaderRepository readerRepository, ReportRepository reportRepository, IReaderService readerService)
{
    public string GenerateReport()
    {
        var reports = reportRepository.GetAllRecords();
        var stringBuilder = new StringBuilder();
        foreach (var report in reports)
        {
            var book = bookRepository.GetBook(report.BookId) ?? new Book() { Title = "Deleted Book" };
            var reader = readerRepository.GetReader(report.ReaderId) ?? new Reader() { Name = "Deleted Reader" };
            stringBuilder.AppendLine($"Book: {book.Title} - Reader: {reader.Name} - Type: {report.Type} - Recording Date: {report.Date}");
        }
        return stringBuilder.ToString();
    }
    
    public void AddReportTypeBorrow(string readerId, string bookId)
    {
        var report = new ReportRecord
        {
            ReaderId = readerId,
            BookId = bookId,
            Type = "Borrow",
            Date = DateTime.Now
        };
        reportRepository.AddRecord(report);
    }
    
    public void AddReportTypeReturn(string readerId, string bookId)
    {
        var report = new ReportRecord
        {
            ReaderId = readerId,
            BookId = bookId,
            Type = "Return",
            Date = DateTime.Now
        };
        reportRepository.AddRecord(report);
    }
    
    public string ReportReaderBorrowedBooks(string readerId)
    {
        var reader = readerRepository.GetReader(readerId);
        if (reader == null)
        {
            return "Reader not found";
        }
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(readerService.GetReaderDetails(readerId));
        foreach (var book in reader.BorrowedBooks)
        {
            stringBuilder.AppendLine($"Book: {book.Title} - Author: {book.Author}");
        }
        return stringBuilder.ToString();
    }
}