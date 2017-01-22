using BangazonTaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BangazonTaskTracker.DAL
{
    public class BangazonRespository
    {
        private readonly BangazonContext Context;
        public BangazonRespository(BangazonContext _context)
        {
            Context = _context;
        }
        // Gets complete list of UserTasks
        public List<UserTask> ReturnTaskList()
        {
            return Context.UserTasks.ToList();
        }
        // Gets a single task based on it's ID
        public UserTask ReturnSingleUserTaskList(int sentTaskId)
        {
            return Context.UserTasks.FirstOrDefault(t => t.Id == sentTaskId);
        }

        // Checks the validity of the sent task and then adds it to the Db if valid
        public UserTask AddTask(UserTask sentUserTask)
        {
            Context.UserTasks.Add(sentUserTask);
            Context.SaveChanges();
            return Context.UserTasks.LastOrDefault(ut => ut.Name == sentUserTask.Name);
        }
    }
}
