using System.Security.Cryptography.X509Certificates;
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
            var tasks = GetTasks() ?? new List<Entities.Task>();
            using StreamWriter file = File.CreateText(_repositoryFilePath);
            {
                tasks.Add(task);
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, tasks);

            }
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
            {
                JsonSerializer serializer = new JsonSerializer();

                return (List<Entities.Task>)serializer.Deserialize(file, typeof(List<Entities.Task>));
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Couldn't get tasks: {e}");
        }
    }

    public List<Entities.Task> GetTasksByStatus(int status)
    {
        List<Entities.Task> tasks = GetTasks();
        var filteredTasks = tasks.Where(task => task.Status == status).ToList();

        return filteredTasks;

    }

    public void DeleteTask(string id)
    {
        List<Entities.Task> tasks = GetTasks();
        Entities.Task? taskToDelete = tasks.Where(task => task.Id == id).FirstOrDefault();
        if (taskToDelete == null)
        {
            throw new Exception($"Task not found with id: {id}");
        } 

        tasks.Remove(taskToDelete);

        using StreamWriter file = File.CreateText(_repositoryFilePath);
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, tasks);
        }
    }

    public void UpdateTask(List<Entities.Task> tasksToUpdate)
    {
        using StreamWriter file = File.CreateText(_repositoryFilePath);
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, tasksToUpdate);
        }
    }
}