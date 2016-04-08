using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPegasus.Web.Models.Customer
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string Email { get; set; }

        public DateTimeOffset Created { get; set; }
    }
}