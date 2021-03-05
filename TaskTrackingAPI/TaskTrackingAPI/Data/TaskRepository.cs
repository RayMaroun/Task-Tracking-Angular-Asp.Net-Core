using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackingAPI.Models;

namespace TaskTrackingAPI.Data
{
    public class TaskRepository : ITaskRepository
    {

        private TaskDetailsContext _context;
        public TaskRepository(TaskDetailsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDetails>> GetTaskDetails()
        {
            return await _context.TaskDetails.ToListAsync();
        }

        public async Task<TaskDetails> GetTaskDetail(int? TaskDetailId)
        {
            return await _context.TaskDetails
                .FirstOrDefaultAsync(e => e.Id == TaskDetailId);
        }

        public async Task<TaskDetails> AddTaskDetail(TaskDetails TaskDetail)
        {
            var result = await _context.TaskDetails.AddAsync(TaskDetail);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TaskDetails> UpdateTaskDetail(TaskDetails TaskDetail)
        {
            var result = await _context.TaskDetails
                .FirstOrDefaultAsync(e => e.Id == TaskDetail.Id);

            if (result != null)
            {
                result.Title = TaskDetail.Title;
                result.Details = TaskDetail.Details;
                result.AssigneeName = TaskDetail.AssigneeName;
                result.Date = TaskDetail.Date;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task DeleteTaskDetail(int? TaskDetailId)
        {
            var result = await _context.TaskDetails
                .FirstOrDefaultAsync(e => e.Id == TaskDetailId);
            if (result != null)
            {
                _context.TaskDetails.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
