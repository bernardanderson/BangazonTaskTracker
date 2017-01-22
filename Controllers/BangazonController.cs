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
        private BangazonRespository newRepo;
        public BangazonController(BangazonRespository repo)
        {
            newRepo = repo;
        }

        // Just so I don't have to repeat checks for Nulls in every return operation
        private IActionResult CheckNullReturnStatus(dynamic sentDbResult, int returnStatusCode, string returnStatusErrMsg)
        {
            if (sentDbResult != null)
            {
                return Ok(sentDbResult);
            }
            return StatusCode(returnStatusCode, returnStatusErrMsg);
        }

        // Gets complete list of UserTasks
        [HttpGet("api/[controller]")]
        public IActionResult GetFullList()
        {
            List<UserTask> userTaskList = newRepo.ReturnTaskList();

            return CheckNullReturnStatus(userTaskList, 415, "No Data to Return");
        }

        /*
        // Gets a single task based on it's ID
        [HttpGet("api/[controller]/{id}")]
        public IActionResult GetSingleTask(int id)
        {
            UserTask newUserTask = newRepo.ReturnTaskList();



            return Ok();
        }

        // POST api/values
        [HttpPost("api/[controller]")]
        public IActionResult Post(UserTask sentTask)
        {
            if (sentTask != null && sentTask.Name == "")
            {
                webAPIRepo.AddNewTask(sentTask);
                return StatusCode(201, "New Task Added");
            }
            return StatusCode(415, "Malformed Task");
        }

        // PUT api/values/5
        [HttpPut("api/[controller]/{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("api/[controller]/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        */
    }
}
