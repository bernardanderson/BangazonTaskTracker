using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonTaskTracker.Models
{
    public enum UserTaskStatus
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
        public UserTaskStatus Status { get; set; }
        public DateTime? CompletedOn { get; set; }
    }
}
