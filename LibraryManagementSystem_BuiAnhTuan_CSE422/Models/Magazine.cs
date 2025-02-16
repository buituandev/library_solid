namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Models;

public class Magazine : Book
{
    public int? Issue { get; init; }
    public string? Topic { get; init; }
    
    public override string ToString()
    {
        return $"Id: {Id} - Title: {Title} - Author: {Author} - Category: {Category} - Quantity: {Quantity} - Issue: {Issue} - Topic: {Topic}";
    }
}