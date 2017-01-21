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

        public UserTask ReturnTaskList()
        {
            return Context.UserTasks.FirstOrDefault(u => u.Id == 1);
        }

        /*
        public void AddNewTask(UserTask sentUserTask)
        {
            Context.UserTasks.Add(sentUserTask);
            Context.SaveChanges();
        }
        */
    }
}
