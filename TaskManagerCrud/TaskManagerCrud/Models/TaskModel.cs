using System.ComponentModel.DataAnnotations;

namespace TaskManagerCrud.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        [MaxLength(100)]    
        public string Name { get; set; } = string.Empty;
        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }  = false;
        public DateTime DueTime { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
