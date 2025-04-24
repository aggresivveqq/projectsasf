using System.ComponentModel.DataAnnotations;

namespace TaskManagerCrud.Models
{
    public class TaskModelDto
    {
        [Required,MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required,MaxLength(100)]
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime DueTime { get; set; }
    }
}
