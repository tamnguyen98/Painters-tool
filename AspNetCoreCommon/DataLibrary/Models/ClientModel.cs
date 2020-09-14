using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Text;

namespace DataLibrary.Models
{
    public class ClientModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [MinLength(2, ErrorMessage = "First name can not be shorter than 2 characters")]
        public string FirstName { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [MinLength(2, ErrorMessage = "Last name can not be shorter than 2 characters")]
        public string LastName { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Email { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [MinLength(10, ErrorMessage = "Phone number must be at least 10 digits")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [MinLength(2, ErrorMessage = "House numbering must be > 2 characters.")]
        public string HouseNum { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [MinLength(2, ErrorMessage = "Please enter a valid street.")]
        public string Street { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string City { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string State { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public decimal? Cost { get; set; }
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [MinLength(2, ErrorMessage = "Project status is required.")]
        public string Status { get; set; }
        public int? ETA { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompleteDate { get; set; }
        public int? ContractorID { get; set; }
    }
}
