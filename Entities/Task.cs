using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskTrackerCLI.Entities;

public class Task
{
    [Required]
    [Key]
    public string Id { get; init;} = Guid.NewGuid().ToString();
    [Required]
    public string Name { get; set;}
    public int? Status { get; set;} = 0;

    public Task () {}

    public Task(string name)
    {
        Name = name;
    }

    public Task(string id, string name, int? status)
    {
        Id = id;
        Name = name;
        Status = status;
    }
}