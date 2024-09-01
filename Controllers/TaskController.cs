using TaskTrackerCLI.Repository;
using TaskTrackerCLI.Entities;
using System.ComponentModel.DataAnnotations;

namespace TaskTrackerCLI.Controllers;

public class TaskController
{
    private readonly IRepository _repository;
    public TaskController(IRepository repository)
    {
        _repository = repository;
    }

    public Entities.Task AddTask(string taskName)
    {
        Entities.Task task = new Entities.Task(taskName);

        _repository.AddTask(task);

        return task;
    }

    public List<Entities.Task> GetTasks()
    {
        return _repository.GetTasks();
    }

    public void UpdateTask(Entities.Task taskToUpdate)
    {
        var tasks = _repository.GetTasks();
        var index = tasks.FindIndex(b => b.Id == taskToUpdate.Id);
        if (index != -1)
        {
            if(!string.IsNullOrEmpty(taskToUpdate.Name))
            {
                tasks[index].Name = taskToUpdate.Name;
            }
            else
            {
                tasks[index].Status = taskToUpdate.Status;
            }
        }
        else
        {
            throw new Exception($"No task with id:{taskToUpdate.Id} found");
        }

        _repository.UpdateTask(tasks);
    }

    public void DeleteTask(string id)
    {
        _repository.DeleteTask(id);
    }
}