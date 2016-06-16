using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.DataAccess.Repositories;
using MyPegasus.DataAccess.Tests.Database;
using MyPegasus.DomainModel.Models;
using NUnit.Framework;

namespace MyPegasus.DataAccess.Tests.Repositories
{
    public abstract class TripRepositoryTest
    {
        [TestFixture]
        public class WhenRetrievingTripById
        {
            private ITrip retrievedTrip;

            [TestFixtureSetUp]
            public void SetUp()
            {
                var mockPegasusContextProvider = new MockPegasusContextProvider();

                var mockCustomer = new Mock<ICustomer>();

                var firstTrip = Task.Run(async () => await Trip.CreateAsync("Trip1", DateTimeOffset.Now, DateTimeOffset.UtcNow, mockCustomer.Object).ConfigureAwait(false)).Result;
                var secondTrip = Task.Run(async () => await Trip.CreateAsync("Trip2", DateTimeOffset.Now, DateTimeOffset.UtcNow, mockCustomer.Object).ConfigureAwait(false)).Result;

                var data = new List<Trip>
                {
                    (Trip)firstTrip.Payload,
                    (Trip)secondTrip.Payload
                }.AsQueryable();


                var firstTripId = firstTrip.Payload.Id;
                mockPegasusContextProvider.SetUpDbSet<Trip>(data);

                var tripRepository = new TripRepository(mockPegasusContextProvider.Context);

                retrievedTrip = Task.Run(async () => await tripRepository.RetrieveByIdAsync(firstTripId).ConfigureAwait(false)).Result;
            }

            [Test]
            public void TheCorrectTripIsRetrieved()
            {
                Assert.AreEqual("Trip1", retrievedTrip.Title);
            }
        }
    }
}
