using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Models
{
    public class TaskStatusModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public bool isComplete { get; set; }
    }
}
