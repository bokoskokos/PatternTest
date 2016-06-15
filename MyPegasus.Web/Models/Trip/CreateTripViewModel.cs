using System;

namespace MyPegasus.Web.Models.Trip
{
    public class CreateTripViewModel
    {
        public string Title { get; set; }
        public DateTimeOffset Departure { get; set; }
        public DateTime Arrival { get; set; }
        public Guid CustomerId { get; set; }
    }
}