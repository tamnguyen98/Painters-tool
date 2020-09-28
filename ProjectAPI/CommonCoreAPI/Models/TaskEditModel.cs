using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCoreAPI.Models
{
    public class TaskEditModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Task { get; set; }
        public string Description { get; set; }
    }
}
