using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackingAPI.Models
{
    public class TaskDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string AssigneeName { get; set; }
        public string Date { get; set; }
    }
}
