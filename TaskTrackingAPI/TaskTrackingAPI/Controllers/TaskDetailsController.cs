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
            try
            {
                var tasks = (await _taskRepository.GetTaskDetails()).ToList();
                if (tasks == null)
                {
                    return NotFound();
                }

                return tasks;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // GET: api/TaskDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetails>> GetTaskDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var taskDetails = await _taskRepository.GetTaskDetail(id);

                if (taskDetails == null)
                {
                    return NotFound();
                }

                return taskDetails;
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT: api/TaskDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskDetails(int id, TaskDetails taskDetails)
        {
            if (id != taskDetails.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _taskRepository.UpdateTaskDetail(taskDetails);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        // POST: api/TaskDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskDetails>> PostTaskDetails(TaskDetails taskDetails)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    await _taskRepository.AddTaskDetail(taskDetails);
                    if (taskDetails.Id > 0)
                    {
                        return CreatedAtAction("GetTaskDetails", new { id = taskDetails.Id }, taskDetails);

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // DELETE: api/TaskDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskDetails>> DeleteTaskDetails(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var model = await _taskRepository.GetTaskDetail(id);

                if (model == null)
                {
                    return NotFound();
                }

                await _taskRepository.DeleteTaskDetail(id);

                return model;

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
