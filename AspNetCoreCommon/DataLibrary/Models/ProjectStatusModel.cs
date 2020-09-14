using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class ProjectStatusModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Project status is required.")]
        public string Status { get; set; }
        public int? ETA { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
