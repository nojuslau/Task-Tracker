using System.ComponentModel.DataAnnotations;

namespace TaskTrackerCLI.Entities;

public class Task
{
    [Required]
    [Key]
    public string Id { get; init;} = Guid.NewGuid().ToString();
    public string? Name { get; set;}
    public int? Status { get; set;}
}