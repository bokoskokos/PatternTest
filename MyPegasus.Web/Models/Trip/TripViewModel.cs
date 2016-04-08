using System;

namespace MyPegasus.Web.Models.Trip
{
    public class TripViewModel
    {
        public Guid Id { get; protected set; }

        public DateTimeOffset Created { get; protected set; }

        public string Title { get; protected set; }

        public DateTimeOffset Departure { get; protected set; }

        public DateTimeOffset Arrival { get; protected set; }
    }
}