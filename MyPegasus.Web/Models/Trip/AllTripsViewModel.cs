using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPegasus.Web.Models.Trip
{
    public class AllTripsViewModel
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}