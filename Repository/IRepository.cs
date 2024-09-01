namespace TaskTrackerCLI.Repository;

public interface IRepository
{
    List<Entities.Task> GetTasks();
    List<Entities.Task> GetTasksByStatus(int status);
    void AddTask(Entities.Task tasks);
    void UpdateTask(List<Entities.Task> tasksToUpdate);
    void DeleteTask(string id);
}