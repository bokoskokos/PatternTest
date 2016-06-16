using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using MyPegasus.Common.Common;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.DomainModel.Models
{
    public class Trip : ITrip
    {
        protected Trip()
        {
        }

        #region Factory

        public static async Task<IOperationResponse<ITrip>> CreateAsync(string title, 
            DateTimeOffset departure, 
            DateTimeOffset arrival, 
            ICustomer customer)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrWhiteSpace(title))
                    return OperationResponse<ITrip>.Error("Title is required");
                if (departure == default(DateTimeOffset))
                    return OperationResponse<ITrip>.Error("Departure is required");
                if (arrival == default(DateTimeOffset))
                    return OperationResponse<ITrip>.Error("Arrival is required");
                if (departure >= arrival)
                    return OperationResponse<ITrip>.Error("Arrival cannot be before departure");
                if (customer == null)
                    return OperationResponse<ITrip>.Error("Arrival cannot be before departure");

                try
                {
                    var trip = new Trip
                    {
                        Title = title,
                        Arrival = arrival,
                        Departure = departure,
                        CustomerInternal = (Customer)customer,
                        Created = DateTimeOffset.UtcNow,
                        Id = Guid.NewGuid()
                    };

                    return OperationResponse<ITrip>.Success(trip);

                }
                catch (Exception ex)
                {
                    var test = ex;
                    throw;
                }

                
                
            });
        }

        #endregion

        [Key]
        public Guid Id { get; protected set; }

        public DateTimeOffset Created { get; protected set; }

        public DateTimeOffset? Deleted { get; protected set; }

        [MaxLength(100)]
        public string Title { get; protected set; }

        public DateTimeOffset Departure { get; protected set; }

        public DateTimeOffset Arrival { get; protected set; }

        public Guid CustomerId { get; protected set; }

        public ICustomer Customer => CustomerInternal;

        public int DepartureTrainStationId { get; protected set; }

        public int ArrivalTrainStationId { get; protected set; }

        #region Navigation Properties

        [ForeignKey("CustomerId")]
        public Customer CustomerInternal { get; protected set; }

        #endregion
    }
}
