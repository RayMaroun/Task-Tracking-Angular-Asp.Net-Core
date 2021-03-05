using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackingAPI.Models;

namespace TaskTrackingAPI.Data
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskDetails>> GetTaskDetails();
        Task<TaskDetails> GetTaskDetail(long taskId);
        Task<TaskDetails> AddTaskDetail(TaskDetails task);
        Task<TaskDetails> UpdateTaskDetail(TaskDetails task);
        Task DeleteTaskDetail(long taskId);
    }
}
