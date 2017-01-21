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
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.UserTasks.Any())
            {
                return;   // DB has been seeded
            }

            UserTask newTask = new UserTask()
            {
                Name = "Go Shopping",
                Description = "Shop for a new pair of shoes",
                Status = 0,
                CompletedOn = DateTime.Now
            };

            context.UserTasks.Add(newTask);
            context.SaveChanges();
        }
    }
}
