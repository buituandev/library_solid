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
            var reader = Readers.FirstOrDefault(r => r.Id == readerId);
            return reader;
        }

        public void RemoveReader(IReader reader)
        {
            Readers.Remove(reader);
        }
    }
}
