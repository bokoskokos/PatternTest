using System;

namespace MyPegasus.Common.DomainModel.Models
{
    public interface ITrip: IDomainModel
    {
        string Title { get; }
        DateTimeOffset Departure { get; }
        DateTimeOffset Arrival { get; }
        ICustomer Customer { get; }
        int DepartureTrainStationId { get; }
        int ArrivalTrainStationId { get; }
    }
}
