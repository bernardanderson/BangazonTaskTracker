using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonTaskTracker.DAL
{
    public class DbInitializer
    {
        public static void Initialize(BangazonContext context)
        {
            // Checks to see if the Db exists
            context.Database.EnsureCreated();

            // Look for any UserTasks.
            if (context.UserTasks.Any())
            {
                return;   // DB has been seeded
            }

            UserTask newTask = new UserTask()
            {
                Name = "Go Shopping",
                Description = "Shop for a new pair of shoes",
                Status = UserTaskStatus.ToDo,
                CompletedOn = null
            };
            context.UserTasks.Add(newTask);

            UserTask newTask1 = new UserTask()
            {
                Name = "Add More Tasks!",
                Description = "Try it out! Add more Tasks!",
                Status = UserTaskStatus.InProgress,
                CompletedOn = null
            };
            context.UserTasks.Add(newTask1);

            context.SaveChanges();
        }
    }
}
