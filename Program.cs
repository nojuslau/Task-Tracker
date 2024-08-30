namespace TaskTrackerCLI;

class Program
{
    private static readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "task.json");
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments provided.");
            return;
        }

        foreach (string arg in args)
        {
            if (arg.Equals("help", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Help: This is a simple command-line program.");
            }
            else if (arg.Equals("version", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Version 1.0.0");
            }
            else if (arg.StartsWith("add ", StringComparison.OrdinalIgnoreCase))
            {
                string name = arg.Substring("add ".Length);
            }
            else if (arg.StartsWith("update ", StringComparison.OrdinalIgnoreCase))
            {
                string name = arg.Substring("update ".Length);
            }
            else if (arg.StartsWith("delete ", StringComparison.OrdinalIgnoreCase))
            {
                string name = arg.Substring("delete ".Length);
            }
            else if (arg.StartsWith("mark-in-progress ", StringComparison.OrdinalIgnoreCase))
            {
                string name = arg.Substring("mark-in-progress ".Length);
            }
            else if (arg.StartsWith("mark-done ", StringComparison.OrdinalIgnoreCase))
            {
                string name = arg.Substring("mark-done ".Length);
            }
            else if (arg.StartsWith("list ", StringComparison.OrdinalIgnoreCase))
            {
                string name = arg.Substring("list ".Length);
            }
            else
            {
                Console.WriteLine($"Unknown argument: {arg}");
            }
        }
    }
}