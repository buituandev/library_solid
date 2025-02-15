using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories
{
    public class ReaderRepository(List<IReader> readers) : IReaderRepository
    {
        public List<IReader> Readers = readers;

        public void AddReader(IReader reader)
        {
            Readers.Add(reader);
        }

        public List<IReader> GetAllReader()
        {
            return Readers;
        }

        public IReader? GetReader(string readerId)
        {
            return Readers.FirstOrDefault(r => r.Id == readerId);
        }

        public void RemoveReader(IReader reader)
        {
            Readers.Remove(reader);
        }
        
        public List<IBook> GetBorrowedBooks(string readerId)
        {
            var reader = GetReader(readerId);
            return reader == null ? [] : reader.BorrowedBooks;
        }
    }
}
