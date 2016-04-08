using System;
using System.ComponentModel.DataAnnotations;

namespace MyPegasus.Web.Models.Customer
{
    public class CreateCustomerViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}