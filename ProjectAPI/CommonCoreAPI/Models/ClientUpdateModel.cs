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
        // Literally the same class as ClientModel without the ContractorID
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="First name can not be shorter than 2 characters")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Last name can not be shorter than 2 characters")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Phone number must be at least 10 digits")]
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "House numbering must be > 2 characters.")]
        public string HouseNum { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid street.")]
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public decimal? Cost { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Project status is required.")]
        public string Status { get; set; }
        public int? ETA { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
    }
}
