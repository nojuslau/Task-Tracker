using Newtonsoft.Json;

namespace TaskTrackerCLI.Repository;

public class Repository : IRepository
{
    private readonly JsonSerializer _serializer;
    private string _repositoryFilePath { get; init; }
    public Repository(string jsonFilePath)
    {
        _serializer = new JsonSerializer();
        _repositoryFilePath = jsonFilePath;
    }
    public void AddTask(Entities.Task task)
    {
        try
        {
            List<Entities.Task> tasks = GetTasks();
            using StreamWriter file = File.CreateText(_repositoryFilePath);
            tasks.Add(task);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, tasks);
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't get tasks: {e}");
        }
    }

    public List<Entities.Task> GetTasks()
    {
        try
        {
            using StreamReader file = File.OpenText(_repositoryFilePath);
            JsonSerializer serializer = new JsonSerializer();

            return (List<Entities.Task>)serializer.Deserialize(file, typeof(List<Entities.Task>));
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't get tasks: {e}");
        }
    }

    public List<Entities.Task> GetTasksByStatus(int status)
    {
        List<Entities.Task> tasks = GetTasks();
        var filteredTasks = from task in tasks
                            where task.Status == status
                            select task;

        return (List<Entities.Task>)filteredTasks;

    }

    public void DeleteTask(Entities.Task task)
    {
        List<Entities.Task> tasks = GetTasks();
        tasks.Remove(task);

        using StreamWriter file = File.CreateText(_repositoryFilePath);
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, tasks);
    }

    public void UpdateTask(Entities.Task task)
    {
        List<Entities.Task> tasks = GetTasks();
        var index = tasks.FindIndex(b => b.Id == task.Id);
        if (index != -1)
        {
            tasks[index] = task;
        }

        using StreamWriter file = File.CreateText(_repositoryFilePath);
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, tasks);
    }
}