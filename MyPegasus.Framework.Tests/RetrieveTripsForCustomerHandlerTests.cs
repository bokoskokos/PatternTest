using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;
using MyPegasus.Framework.Handlers;
using NUnit.Framework;

namespace MyPegasus.Framework.Tests
{
    public class RetrieveTripsForCustomerHandlerTests
    {
        [TestFixture]
        public class WhenRetrievingTripsForCustomer
        {
            private readonly Guid _customerId = new Guid("0FE4E987-26DF-4C78-9154-28CD6B22AC5E");
            private RetrieveTripsForCustomerHandlerResponse _respose;
            private readonly Mock<ITripRepository> _mockTripRepository = new Mock<ITripRepository>();
            private readonly Mock<ITrip> _mockTrip = new Mock<ITrip>();

            [TestFixtureSetUp]
            public void SetUp()
            {
                IEnumerable<ITrip> trips = new List<ITrip> {_mockTrip.Object};
                _mockTripRepository.Setup(mock => mock.RetrieveByCustomerIdAsync(_customerId)).Returns(Task.FromResult(trips));

                var handler = new RetrieveTripsForCustomerHandler(_mockTripRepository.Object);

                _respose = Task.Run(
                    async () =>
                        await handler.HandleAsync(new RetrieveTripsForCustomerHandlerRequest {CustomerId = _customerId}).ConfigureAwait(false)).Result;
            }

            [Test]
            public void TheRepositoryIsCalledCorrectly()
            {
                _mockTripRepository.Verify(mock => mock.RetrieveByCustomerIdAsync(_customerId), Times.Once);
            }

            [Test]
            public void TheCorrectTripIsReturned()
            {
                Assert.AreSame(_mockTrip.Object, _respose.Trips.Single());
            }
        }
    }
}
