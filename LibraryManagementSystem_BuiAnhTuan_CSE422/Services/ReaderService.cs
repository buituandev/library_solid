using System.Text;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services
{
    public class ReaderService(IReaderRepository readerRepository) : IReaderService
    {
        public void AddReader(string readerName)
        {
            var reader = new Reader
            {
                Id = Guid.NewGuid().ToString().Replace("-", ""),
                Name = readerName,
                BorrowedBooks = []
            };
            readerRepository.AddReader(reader);
        }

        public void RemoveReader(string readerId)
        {
            var reader = readerRepository.GetReader(readerId);
            if (reader != null)
            {
                readerRepository.RemoveReader(reader);
            }
        }

        public IReader? GetReader(string readerId)
        {
            return readerRepository.GetReader(readerId);
        }

        public string GetReaderDetails(string readerId)
        {
            var reader = readerRepository.GetReader(readerId);
            return reader == null ? "Reader not found" : $"Reader ID: {reader.Id} - Name: {reader.Name}";
        }

        public void UpdateReaderInfo(string name, string readerId)
        {
            var reader = readerRepository.GetReader(readerId);
            if (reader == null) return;
            reader.Name = name;
            readerRepository.RemoveReader(reader);
            readerRepository.AddReader(reader);
        }

        public bool CanBorrowMoreBooks(string readerId)
        {
            var borrowedBooks = readerRepository.GetBorrowedBooks(readerId);
            return borrowedBooks.Count < 3;
        }

        public string ShowAllReaders()
        {
            var readers = readerRepository.GetAllReader();
            var stringBuilder = new StringBuilder();
            foreach (var reader in readers)
            {
                stringBuilder.AppendLine(reader.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}