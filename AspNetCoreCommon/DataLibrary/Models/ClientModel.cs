using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace DataLibrary.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "House numbering must be > 2 characters.")]
        public string HouseNum { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter a valid street.")]
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price (greater than 0).")]
        public decimal Cost { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "A status is required.")]
        public string Status { get; set; }
        public int ETA { get; set; }
        public SqlDateTime? StartDate { get; set; }
        public SqlDateTime? CompleteDate { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "A contractor ID is required.")]
        public int ContractorID { get; set; }
    }
}
