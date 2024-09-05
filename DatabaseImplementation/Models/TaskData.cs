

using DatabaseImplementation.Enums;
using System.ComponentModel.DataAnnotations;

namespace DatabaseImplementation.Models
{
    public class TaskData
    {
        public int? Id { get; set; }

        [Required] 
        public string TaskName { get; set; }

        [Required]
        public TaskStates TaskState { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public bool IsFavorite { get; set; }

    }
}
