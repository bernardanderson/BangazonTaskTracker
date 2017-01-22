using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BangazonTaskTracker.Models;
using BangazonTaskTracker.DAL;

namespace BangazonTaskTracker.Controllers
{
    public class BangazonController : Controller
    {
        // The Repo isn't created using a "new" as the repo Class has been scoped to allow the Repo access to DI'd context
        private BangazonRepository newRepo;
        public BangazonController(BangazonRepository repo)
        {
            newRepo = repo;
        }

        // Just so I don't have to repeat checks for Nulls in every return operation
        private IActionResult CheckNullReturnStatus(dynamic sentDbResult, int returnStatusGoodCode, int returnStatusErrCode, string returnStatusErrMsg)
        {
            if (sentDbResult != null)
            {
                return StatusCode(returnStatusGoodCode, sentDbResult);
            }
            return StatusCode(returnStatusErrCode, returnStatusErrMsg);
        }

        // Checks to see if a UserTask is malformed or null
        private bool InvalidUserTask (dynamic sentTask)
        {
            if (sentTask == null ||
                sentTask.Name == "" ||
               (sentTask.Status < UserTaskStatus.ToDo || sentTask.Status > UserTaskStatus.Complete) ||
               sentTask.Description == "" ||
               sentTask.Id < 0 )
            {
                return true;
            }
            return false;
        }

        // Gets complete list of UserTasks
        [HttpGet("api/[controller]")]
        public IActionResult GetFullList()
        {
            List<UserTask> userTaskList = newRepo.ReturnTaskList();
            return CheckNullReturnStatus(userTaskList, 200, 204, "");
        }

        // Gets a single task based on it's ID
        [HttpGet("api/[controller]/{taskId:int}")]
        public IActionResult GetSingleTask(int taskId)
        {
            UserTask returnedUserTask = newRepo.ReturnSingleUserTaskList(taskId);
            return CheckNullReturnStatus(returnedUserTask, 200, 204, "");
        }
        // Gets a single task based on it's ID
        [HttpGet("api/[controller]/stat/{statusId:int}")]
        public IActionResult GetStatusTaskList(int statusId)
        {
            List<UserTask> returnedStatusUserTasks = newRepo.ReturnStatusUserTaskList(statusId);
            return CheckNullReturnStatus(returnedStatusUserTasks, 200, 204, "");
        }
        // Checks to see if the submitted user task is valid and if so, adds the new Task to the Database and returns the new task to the client
        [HttpPost("api/[controller]")]
        public IActionResult PostTaskToDb([FromBody]UserTask sentTask)
        {
            if (InvalidUserTask(sentTask))
            {
                return StatusCode(415, "Malformed User Task Received");
            }

            UserTask returnedDbTask = newRepo.AddTask(sentTask);
            if (returnedDbTask == null)
            {
                return StatusCode(415, "User Task Not Added to Db. Should you update (PUT) instead of add (POST)?");
            }
            return StatusCode(201, returnedDbTask);
        }
        
        // Checks to see the submitted user task is valid and if so, updates the Task.
        [HttpPut("api/[controller]")]
        public IActionResult UpdateTaskToDb([FromBody]UserTask sentTask)
        {
            if (InvalidUserTask(sentTask))
            {
                return StatusCode(415, "Malformed User Task Received");
            }
            UserTask returnedDbUserTask = newRepo.UpdateTask(sentTask);

            if (returnedDbUserTask == null)
            {
                return StatusCode(415, "User Task not Found in Db. Should you add (POST) instead of update (PUT)?");
            }
            return StatusCode(201, returnedDbUserTask);
        }

        // Deletes the userTask based on it's Id
        [HttpDelete("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            UserTask deletedTask = newRepo.DeleteTask(id);
            if (deletedTask == null)
            {
                return StatusCode(415, "Task Not Deleted. Is it in the database?");
            }
            return Ok(deletedTask);
        }
    }
}
