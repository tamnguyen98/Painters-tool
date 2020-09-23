using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class TaskModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Task { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
        public bool Complete { get; set; }
        public int ETA { get; set; }
    }
}
