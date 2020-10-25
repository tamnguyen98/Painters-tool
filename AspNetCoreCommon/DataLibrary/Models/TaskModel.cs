using DataLibrary.CustomMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{
    public class TaskModel
    {
        private string _task;
        private string _description;

        [Required]
        public int Id { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Task
        {
            get { return _task; }
            set { _task = ReturnData.TrimStringValue(value); }
        }
        [MaxLength(25)]
        public string Description
        {
            get { return _description; }
            set { _description = value.Trim(); }
        }
        public bool Complete { get; set; }
        public int ETA { get; set; }
    }
}
