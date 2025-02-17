using System.Text;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services;

public class ReportService(
    IReaderRepository readerRepository,
    ReportRepository reportRepository,
    IReaderService readerService)
{
    public string GenerateReport()
    {
        var readers = readerRepository.GetAllReader();
        var stringBuilder = new StringBuilder();
        foreach (var reader in readers)
        {
            if (reader.Id != null) stringBuilder.AppendLine(readerService.GetReaderDetails(reader.Id));
            if (reader.BorrowedBooks == null) continue;
            foreach (var book in reader.BorrowedBooks)
            {
                stringBuilder.AppendLine($"Book: {book.Title} - Author: {book.Author}");
            }
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
}