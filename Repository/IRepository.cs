namespace TaskTrackerCLI.Repository;

public interface IRepository
{
    List<Entities.Task> GetTasks();
    List<Entities.Task> GetTasksByStatus(int status);
    void AddTask(Entities.Task tasks);
    void UpdateTask(Entities.Task task);
    void DeleteTask(Entities.Task task);
}