using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCoreAPI.Models
{
    public class ClientUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string HouseNum { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Cost { get; set; }
        [Required]
        public string Status { get; set; }
        public int? ETA { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
