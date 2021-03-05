using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTrackingAPI.Data;
using TaskTrackingAPI.Models;

namespace TaskTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskDetailsController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskDetailsController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/TaskDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDetails>>> GetTaskDetails()
        {
            return (await _taskRepository.GetTaskDetails()).ToList();
        }

        // GET: api/TaskDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetails>> GetTaskDetails(long id)
        {
            var taskDetails = await _taskRepository.GetTaskDetail(id);

            if (taskDetails == null)
            {
                return NotFound();
            }

            return taskDetails;
        }

        // PUT: api/TaskDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDetails(long id, TaskDetails taskDetails)
        {
            if (id != taskDetails.Id)
            {
                return BadRequest();
            }

            await _taskRepository.UpdateTaskDetail(taskDetails);

            return NoContent();
        }

        // POST: api/TaskDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskDetails>> PostTaskDetails(TaskDetails taskDetails)
        {
            await _taskRepository.AddTaskDetail(taskDetails);

            return CreatedAtAction("GetTaskDetails", new { id = taskDetails.Id }, taskDetails);
        }

        // DELETE: api/TaskDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskDetails>> DeleteTaskDetails(long id)
        {
            var model = await _taskRepository.GetTaskDetail(id);

            if (model == null)
            {
                return NotFound();
            }

            await _taskRepository.DeleteTaskDetail(id);

            return model;
        }
    }
}
