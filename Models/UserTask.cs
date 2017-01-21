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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}
