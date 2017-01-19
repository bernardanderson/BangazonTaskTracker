using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonTaskTracker.Models
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Complete
    };

    public class UserTask
    {
        [Key]
        public int Id;
        [Required]
        public string Name;
        [Required]
        public string Description;
        [Required]
        public TaskStatus Status;
        public DateTime CompletedOn;
    }
}
