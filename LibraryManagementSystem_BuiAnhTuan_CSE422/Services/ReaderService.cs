using LibraryManagementSystem_BuiAnhTuan_CSE422.Interfaces;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.Services
{
    public class ReaderService(IReaderRepository readerRepository) : IReaderService
    {
        public IReaderRepository ReaderRepository = readerRepository;

        public string GetReaderDetails(string readerId)
        {
            var reader = ReaderRepository.GetReader(readerId);
            if (reader == null)
            {
                return "Reader not found";
            }
            return $"Reader ID: {reader.Id}, Name: {reader.Name}";
        }

        public void RegisterReader(string readerId, string readerName)
        {

        }

        public void UpdateReaderInfo(IReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
