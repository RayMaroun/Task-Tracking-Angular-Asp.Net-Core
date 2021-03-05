using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackingAPI.Models
{
    public class TaskDetailsContext : DbContext
    {
        public TaskDetailsContext(DbContextOptions<TaskDetailsContext> options)
            : base(options)
        {
        }

        public DbSet<TaskDetails> TaskDetails { get; set; }
    }
}
