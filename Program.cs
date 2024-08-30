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


        if (args[0] == "--help")
        {
            Console.WriteLine("Help: This is a simple command-line program.");
        }
        else if (args[0] == "--version")
        {
            Console.WriteLine("Version 1.0.0");
        }
        else if (args[0] == "--add")
        {
            string options = args.ToString().Replace("--add ", "");
        }
        else if (args[0] == "--update")
        {
            string options = args.ToString().Replace("--update ", "");
        }
        else if (args[0] == "--delete")
        {
            string options = args.ToString().Replace("--delete ", "");
        }
        else if (args[0] == "--mark-in-progress")
        {
            string options = args.ToString().Replace("--mark-in-progress ", "");
        }
        else if (args[0] == "--mark-done")
        {
            string options = args.ToString().Replace("--mark-done ", "");
        }
        else if (args[0] == "--list" && args.Length < 3)
        {

            if (args.Length < 2)
            {

            }
            else if (args[1] == "done")
            {
                
            }
            else if (args[1] == "todo")
            {

            }
            else if (args[1] == "in-progress")
            {
                
            }
        }
        else
        {
            Console.WriteLine($"Unknown argument: {args}");
        }
    }
}