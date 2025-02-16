using LibraryManagementSystem_BuiAnhTuan_CSE422.Database;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Models;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Repositories;
using LibraryManagementSystem_BuiAnhTuan_CSE422.Services;
using LibraryManagementSystem_BuiAnhTuan_CSE422.UI;

class Program
{
    private static void Main()
    {
        var bookRepository = new BookRepository(Data.Books);
        var readerRepository = new ReaderRepository(Data.Readers);
        var reportRepository = new ReportRepository(Data.Records);

        var readerService = new ReaderService(readerRepository);
        var bookService = new BookService(bookRepository);
        var reportService = new ReportService(bookRepository, readerRepository, reportRepository, readerService);
        var lendingService = new LendingService(bookRepository, readerRepository, readerService, bookService, reportService);

        ConsoleUi.ShowWelcomeMessage();

        int option;
        do
        {
            ConsoleUi.ShowMenu();
            option = ConsoleUi.GetMenuOption();
            HandleMainMenuOption(option, readerService, bookService, reportService, lendingService);
        } while (option != 9);
    }

    private static void HandleMainMenuOption(int option, ReaderService readerService, BookService bookService, ReportService reportService, LendingService lendingService)
    {
        switch (option)
        {
            case 1:
                HandleReaderManagement(readerService);
                break;
            case 2:
                HandleBookManagement(bookService);
                break;
            case 3:
                Console.WriteLine(ConsoleUi.InputForMethodReturn<string>("BorrowBook", lendingService));
                break;
            case 4:
                Console.WriteLine(ConsoleUi.InputForMethodReturn<string>("ReturnBook", lendingService));
                break;
            case 5:
                ConsoleUi.ShowTable(bookService.ShowAllBooks());
                break;
            case 6:
                ConsoleUi.ShowTable(readerService.ShowAllReaders());
                break;
            case 7:
                ConsoleUi.ShowTable(ConsoleUi.InputForMethodReturn<string>("ReportReaderBorrowedBooks", reportService));
                break;
            case 8:
                ConsoleUi.ShowTable(reportService.GenerateReport());
                break;
        }
    }

    private static void HandleReaderManagement(ReaderService readerService)
    {
        int readerOption;
        do
        {
            ConsoleUi.ShowReaderManagementMenu();
            readerOption = ConsoleUi.GetMenuOption();

            switch (readerOption)
            {
                case 1:
                    ConsoleUi.Input<Reader>("AddReader", readerService);
                    break;
                case 2:
                    ConsoleUi.ShowTable(readerService.ShowAllReaders());
                    break;
            }
        } while (readerOption != 3);
    }

    private static void HandleBookManagement(BookService bookService)
    {
        int bookOption;
        do
        {
            ConsoleUi.ShowBookManagementMenu();
            bookOption = ConsoleUi.GetMenuOption();

            switch (bookOption)
            {
                case 1:
                    ConsoleUi.Input<Book>("AddBook", bookService);
                    break;
                case 2:
                    ConsoleUi.Input<EBook>("AddEbook", bookService);
                    break;
                case 3:
                    ConsoleUi.Input<Magazine>("AddMagazine", bookService);
                    break;
                case 4:
                    ConsoleUi.ShowTable(bookService.ShowAllBooks());
                    break;
                case 5:
                    ConsoleUi.ShowTable(ConsoleUi.InputForMethodReturn<string>("GetBookByAuthor", bookService));
                    break;
                case 6:
                    ConsoleUi.ShowTable(ConsoleUi.InputForMethodReturn<string>("GetBookByTitle", bookService));
                    break;
            }
        } while (bookOption != 7);
    }
}
