namespace TaskTrackerCLI.Entities;

public class Constants
{
    public const int NotDone = 0;
    public const int InProgress = 1;
    public const int Done = 2;

    public Dictionary<int, string> States = new Dictionary<int, string>(){
        { NotDone, "Not Done" },
        { InProgress, "In Progress" },
        { Done, "Done" },
    };
}