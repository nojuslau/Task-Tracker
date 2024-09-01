using System.Text;
using Microsoft.VisualBasic;
using TaskTrackerCLI.Controllers;
using TaskTrackerCLI.Repository;

namespace TaskTrackerCLI;

class Program
{
    private static readonly string _jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "task.json");
    static void Main(string[] args)
    {
        int argsLength = args.Length;
        Repository.Repository repository = new Repository.Repository(_jsonFilePath);
        TaskController taskController = new TaskController(repository);

        if (!File.Exists(_jsonFilePath))
        {
            using (FileStream fs = File.Create(_jsonFilePath))
            {
            }
        }

        if (argsLength == 0)
        {
            Console.WriteLine("No arguments provided.");
            return;
        }

        switch (args[0])
        {
            case "--help":
                Console.WriteLine("Help: This is a simple command-line program.");
                break;
            case "--version":
                Console.WriteLine("Version 1.0.0");
                break;
            case "--add":
                if (argsLength > 2)
                {
                    string argsText = string.Join(" ", args).Replace("--add ", "");
                    Console.WriteLine($"Unknown options: {argsText}");

                    break;
                }

                string taskName = string.Join(" ", args).Replace("--add ", "");
                Entities.Task newTask = taskController.AddTask(taskName);
                Console.WriteLine($"Output: Task added successfully (ID: {newTask.Id})");

                break;
            case "--update":
                if (argsLength > 3)
                {
                    string argsText = string.Join(" ", args).Replace("--update ", "");
                    Console.WriteLine($"Unknown options: {argsText}");

                    break;
                }

                Entities.Task taskToUpdateName = new Entities.Task(args[1], args[2], 0);

                taskController.UpdateTask(taskToUpdateName);
                Console.WriteLine($"Output: Task name updated successfully (ID: {args[1]})");

                break;
            case "--delete":
                if (argsLength > 2)
                {
                    string argsText = string.Join(" ", args).Replace("--delete ", "");
                    Console.WriteLine($"Unknown options: {argsText}");

                    break;
                }

                taskController.DeleteTask(args[1]);
                Console.WriteLine($"Output: Task deleted successfully (ID: {args[1]})");

                break;
            case "--mark-in-progress":
                if (argsLength > 2)
                {
                    string argsText = string.Join(" ", args).Replace("--mark-in-progress ", "");
                    Console.WriteLine($"Unknown options: {argsText}");

                    break;
                }

                Entities.Task taskToUpdateStatusMIP = new Entities.Task(args[1], "", Entities.Constants.InProgress);
                taskController.UpdateTask(taskToUpdateStatusMIP);
                Console.WriteLine($"Output: Task status updated successfully (ID: {args[1]})");

                break;
            case "--mark-done":
                if (argsLength > 2)
                {
                    string argsText = string.Join(" ", args).Replace("--mark-in-progress ", "");
                    Console.WriteLine($"Unknown options: {argsText}");

                    break;
                }

                Entities.Task taskToUpdateStatusDone = new Entities.Task(args[1], "", Entities.Constants.Done);
                taskController.UpdateTask(taskToUpdateStatusDone);
                Console.WriteLine($"Output: Task status updated successfully (ID: {args[1]})");

                break;
            case "--list":
                if (argsLength < 2)
                {
                    List<Entities.Task> taskList = taskController.GetTasks();
                    taskList.ForEach(task => Console.WriteLine($"task id: {task.Id} name: {task.Name} status: {Entities.Constants.States[task.Status ?? 0]}"));
                }
                else if (args[1] == "done")
                {
                    List<Entities.Task> taskList = taskController.GetTasks();
                    taskList = taskList.Where(task => task.Status == Entities.Constants.Done).ToList();
                    taskList.ForEach(task => Console.WriteLine($"task id: {task.Id} name: {task.Name} status: {Entities.Constants.States[task.Status ?? 0]}"));
                }
                else if (args[1] == "todo")
                {
                    List<Entities.Task> taskList = taskController.GetTasks();
                    taskList = taskList.Where(task => task.Status == Entities.Constants.NotDone).ToList();
                    taskList.ForEach(task => Console.WriteLine($"task id: {task.Id} name: {task.Name} status: {Entities.Constants.States[task.Status ?? 0]}"));
                }
                else if (args[1] == "in-progress")
                {
                    List<Entities.Task> taskList = taskController.GetTasks();
                    taskList = taskList.Where(task => task.Status == Entities.Constants.InProgress).ToList();
                    taskList.ForEach(task => Console.WriteLine($"task id: {task.Id} name: {task.Name} status: {Entities.Constants.States[task.Status ?? 0]}"));
                }
                else
                {
                    Console.WriteLine($"Unknown options: {args}");
                }
                break;
            default:
                Console.WriteLine($"Unknown argument: {args}");
                break;
        }
    }
}