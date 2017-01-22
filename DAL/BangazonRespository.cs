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
            // Quick check to make sure the thing being added doesn't already exist (by Id)
            if (Context.UserTasks.FirstOrDefault(ut => ut.Id == sentUserTask.Id) == null)
            {
                Context.UserTasks.Add(sentUserTask);
                Context.SaveChanges();
                return Context.UserTasks.LastOrDefault(ut => ut.Name == sentUserTask.Name);
            }
            return (sentUserTask = null);
        }

        // Takes a sentUserTask and finds it in the Db. If not present, then it returns null.
        //  If it is found, it is updated with the new data. If the use set it to "complete" then a Datetime is added
        public UserTask UpdateTask(UserTask sentUserTask)
        {
            UserTask updatingUserTask = Context.UserTasks.FirstOrDefault(ut => ut.Id == sentUserTask.Id);

            if (updatingUserTask == null)
            {
                return updatingUserTask;
            }
            Context.UserTasks.Update(updatingUserTask);

            updatingUserTask.Name = sentUserTask.Name;
            updatingUserTask.Description = sentUserTask.Description;
            updatingUserTask.Status = sentUserTask.Status;

            // Sets the completed date if the user has set the task to "complete"
            if (sentUserTask.Status == UserTaskStatus.Complete)
            {
                updatingUserTask.CompletedOn = DateTime.Now;
            } else
            {
                updatingUserTask.CompletedOn = null;
            }

            Context.SaveChanges();
            return updatingUserTask;
        }
        public UserTask DeleteTask(int sentId)
        {
            UserTask foundTask = Context.UserTasks.FirstOrDefault(ut => ut.Id == sentId);

            if (foundTask != null)
            {
                Context.UserTasks.Remove(foundTask);
                Context.SaveChanges();
            }
            return foundTask;
        }
    }
}
