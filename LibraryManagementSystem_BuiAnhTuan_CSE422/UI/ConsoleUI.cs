using System.Text.RegularExpressions;

namespace LibraryManagementSystem_BuiAnhTuan_CSE422.UI;

public static partial class ConsoleUi
{
    private static void PrintHeader(string title)
    {
        Console.WriteLine("\n╔═══════════════════════════════════╗");
        Console.WriteLine($"║  {title,-33}║");
        Console.WriteLine("╚═══════════════════════════════════╝");
    }

    public static void ShowWelcomeMessage()
    {
        PrintHeader("Library Management System");
    }

    public static void ShowMenu()
    {
        PrintHeader("Main Menu");
        Console.WriteLine("  [1] Reader Management");
        Console.WriteLine("  [2] Book Management");
        Console.WriteLine("  [3] Borrow Book");
        Console.WriteLine("  [4] Return Book");
        Console.WriteLine("  [5] Show All Books");
        Console.WriteLine("  [6] Show All Readers");
        Console.WriteLine("  [7] Generate Report");
        Console.WriteLine("  [8] Exit");
    }

    public static void ShowReaderManagementMenu()
    {
        PrintHeader(" Reader Management");
        Console.WriteLine("  [1] Add Reader");
        Console.WriteLine("  [2] Show All Readers");
        Console.WriteLine("  [3] Back");
    }

    public static void ShowBookManagementMenu()
    {
        PrintHeader(" Book Management");
        Console.WriteLine("  [1] Add Book");
        Console.WriteLine("  [2] Add eBook");
        Console.WriteLine("  [3] Add Magazine");
        Console.WriteLine("  [4] Show All Books");
        Console.WriteLine("  [5] Search Book by Author");
        Console.WriteLine("  [6] Search Book by Title");
        Console.WriteLine("  [7] Back");
    }
    
    public static int GetMenuOption()
    {
        Console.Write("Enter your choice: ");
        var input = Console.ReadLine();
        return int.TryParse(input, out var option) ? option : -1;
    }
    
    public static T InputForMethodReturn<T>(string methodName, object instance)
    {
        var method = instance.GetType().GetMethod(methodName);
        if (method == null)
        {
            Console.WriteLine($"Method '{methodName}' not found in {instance.GetType().Name}.");
            return default!;
        }
    
        var parameters = method.GetParameters();
        var args = new object?[parameters.Length];
    
        Console.WriteLine($"\nEnter details information below:");
    
        for (var i = 0; i < parameters.Length; i++)
        {
            var paramType = parameters[i].ParameterType;
    
            if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(List<>))
            {
                continue;
            }
    
            Console.Write($"Enter {parameters[i].Name}: ");
            var input = Console.ReadLine();
    
            args[i] = Convert.ChangeType(input, paramType);
        }
        return (T)method.Invoke(instance, args)!;
    }
    
    public static void InputForMethod(string methodName, object instance)
    {
        var method = instance.GetType().GetMethod(methodName);
        if (method == null)
        {
            Console.WriteLine($"Method '{methodName}' not found in {instance.GetType().Name}.");
            return;
        }

        var parameters = method.GetParameters();
        var args = new object?[parameters.Length];

        Console.WriteLine($"\nEnter details information below:");

        for (var i = 0; i < parameters.Length; i++)
        {
            var paramType = parameters[i].ParameterType;

            if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(List<>))
            {
                continue;
            }

            Console.Write($"Enter {parameters[i].Name}: ");
            var input = Console.ReadLine();

            args[i] = Convert.ChangeType(input, paramType);
        }
        method.Invoke(instance, args);
    }
    
    public static void Input<T>(string methodName, object instance) where T : class, new()
    {
        var method = instance.GetType().GetMethod(methodName);
        if (method == null)
        {
            Console.WriteLine($"Method '{methodName}' not found in {instance.GetType().Name}.");
            return;
        }

        var parameters = method.GetParameters();
        var args = new object?[parameters.Length];

        Console.WriteLine($"\nEnter details information below:");

        for (var i = 0; i < parameters.Length; i++)
        {
            var paramType = parameters[i].ParameterType;

            if (paramType.IsGenericType && paramType.GetGenericTypeDefinition() == typeof(List<>))
            {
                continue;
            }

            Console.Write($"Enter {parameters[i].Name}: ");
            var input = Console.ReadLine();

            args[i] = Convert.ChangeType(input, paramType);
        }
        method.Invoke(instance, args);
    }

    public static void ShowTable(string format)
    {
        var lines = format.Split(["\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries);
        var dataGroups = new List<Dictionary<string, string>>();
        var currentGroup = new Dictionary<string, string>();

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            var matches = MyRegex().Matches(trimmedLine);

            if (matches.Count <= 0) continue;
            var firstKey = matches[0].Groups[1].Value.Trim();
            if (currentGroup.Count > 0 && currentGroup.ContainsKey(firstKey))
            {
                dataGroups.Add(new Dictionary<string, string>(currentGroup));
                currentGroup.Clear();
            }

            foreach (Match match in matches)
            {
                var key = match.Groups[1].Value.Trim();
                var value = match.Groups[2].Value.Trim();

                if (!currentGroup.TryAdd(key, value))
                    currentGroup[key] += ", " + value;
            }
        }

        if (currentGroup.Count > 0)
        {
            dataGroups.Add(new Dictionary<string, string>(currentGroup));
        }
        var headers = dataGroups.SelectMany(dict => dict.Keys).Distinct().ToList();
        var columnWidths = headers.ToDictionary(header => header, header =>
            Math.Max(header.Length, dataGroups.Max(dict => dict.TryGetValue(header, out var value1) ? value1.Length : 0)));

        Console.WriteLine("+-" + string.Join("-+-", headers.Select(h => new string('-', columnWidths[h]))) + "-+");
        Console.WriteLine("| " + string.Join(" | ", headers.Select(h => h.PadRight(columnWidths[h]))) + " |");
        Console.WriteLine("+-" + string.Join("-+-", headers.Select(h => new string('-', columnWidths[h]))) + "-+");
        foreach (var row in dataGroups)
        {
            Console.WriteLine("| " + string.Join(" | ",
                headers.Select(h =>
                    row.TryGetValue(h, out var value) ? value.PadRight(columnWidths[h]) : new string(' ', columnWidths[h]))) + " |");
        }
        Console.WriteLine("+-" + string.Join("-+-", headers.Select(h => new string('-', columnWidths[h]))) + "-+");
    }
    
    public static void ShowReportTable(string format)
{
    var lines = format.Split(["\n", "\r\n"], StringSplitOptions.RemoveEmptyEntries);
    var dataGroups = new List<List<Dictionary<string, string>>>();
    var currentGroup = new List<Dictionary<string, string>>();

    foreach (var line in lines)
    {
        var trimmedLine = line.Trim();
        var matches = MyRegex().Matches(trimmedLine);
        if (matches.Count <= 0) continue;

        var firstKey = matches[0].Groups[1].Value.Trim();
        if (firstKey == "Reader")
        {
            if (currentGroup.Count > 0)
            {
                dataGroups.Add([..currentGroup]);
                currentGroup.Clear();
            }
        }

        var dataRow = new Dictionary<string, string>();
        foreach (Match match in matches)
        {
            var key = match.Groups[1].Value.Trim();
            var value = match.Groups[2].Value.Trim();
            dataRow[key] = value;
        }
        currentGroup.Add(dataRow);
    }
    if (currentGroup.Count > 0)
    {
        dataGroups.Add([..currentGroup]);
    }

    foreach (var readerGroup in dataGroups)
    {
        var headers = readerGroup.SelectMany(dict => dict.Keys).Distinct().ToList();
        var columnWidths = headers.ToDictionary(header => header, header =>
            Math.Max(header.Length, readerGroup.Max(dict => dict.TryGetValue(header, out var value1) ? value1.Length : 0)));

        Console.WriteLine("+-" + string.Join("-+-", headers.Select(h => new string('-', columnWidths[h]))) + "-+");
        Console.WriteLine("| " + string.Join(" | ", headers.Select(h => h.PadRight(columnWidths[h]))) + " |");
        Console.WriteLine("+-" + string.Join("-+-", headers.Select(h => new string('-', columnWidths[h]))) + "-+");

        foreach (var row in readerGroup)
        {
            Console.WriteLine("| " + string.Join(" | ",
                headers.Select(h =>
                    row.TryGetValue(h, out var value) ? value.PadRight(columnWidths[h]) : new string(' ', columnWidths[h]))) + " |");
        }
        Console.WriteLine("+-" + string.Join("-+-", headers.Select(h => new string('-', columnWidths[h]))) + "-+");
        Console.WriteLine();
    }
}

    [GeneratedRegex(@"([^:]+): ([^-\n]+)")]
    private static partial Regex MyRegex();
}