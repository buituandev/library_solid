using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories;

public class ReportRepository(List<ReportRecord> records)
{
    public void AddRecord(ReportRecord record)
    {
        records.Add(record);
    }
    
    public List<ReportRecord> GetAllRecords()
    {
        return records;
    }
    
    public List<ReportRecord> GetRecordsByUserId(string userId)
    {
        return records.Where(r => r.ReaderId == userId).ToList();
    }
    
    public List<ReportRecord> GetRecordsByBookId(string bookId)
    {
        return records.Where(r => r.BookId == bookId).ToList();
    }
    
    public List<ReportRecord> GetRecordsByType(string type)
    {
        return records.Where(r => r.Type == type).ToList();
    }
    
    public List<ReportRecord> GetRecordsByDate(DateTime date)
    {
        return records.Where(r => r.Date == date).ToList();
    }
}