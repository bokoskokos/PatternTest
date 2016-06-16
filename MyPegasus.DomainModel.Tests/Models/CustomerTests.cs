using System;
using System.Threading.Tasks;
using MyPegasus.Common.Common;
using MyPegasus.DomainModel.Models;
using NUnit.Framework;

namespace MyPegasus.DomainModel.Tests.Models
{
    public class CustomerTests
    {
        [TestFixture]
        public class WhenSettingEmail
        {
            private Customer _customer;
            private IOperationResponse _response;
            private const string NewEmailAddress = "new@gmail.com";

            [TestFixtureSetUp]
            public void Setup()
            {
                var createCustomerResponse = Task.Run(async () => await 
                    Customer.CreateAsync("Bosko", 
                    "Kovacevic", 
                    "bosko.kovacevic@gmail.com", 
                    DateTimeOffset.Parse("03/11/1983")
                ).ConfigureAwait(false)).Result;

                _customer = createCustomerResponse.Payload;
                _response = _customer.SetEmail(NewEmailAddress);
            }

            [Test]
            public void TheNewEmailIsSet()
            {
                Assert.AreEqual(NewEmailAddress, _customer.Email);
            }

            [Test]
            public void TheResponseIsSuccessful()
            {
                Assert.IsTrue(_response.IsOk);
            }
        }

        [TestFixture]
        public class WhenSettingEmailWithInvalidEmail
        {
            private Customer _customer;
            private IOperationResponse _response;
            private const string OriginalEmailAddress = "bosko.kovacevic@gmail.com";

            [TestFixtureSetUp]
            public void Setup()
            {
                var createCustomerResponse = Task.Run(async () => await
                    Customer.CreateAsync("Bosko",
                    "Kovacevic",
                    OriginalEmailAddress,
                    DateTimeOffset.Parse("03/11/1983")
                ).ConfigureAwait(false)).Result;

                _customer = createCustomerResponse.Payload;
                _response = _customer.SetEmail("SomeInvalidEmail");
            }

            [Test]
            public void TheNewEmailIsNotSet()
            {
                Assert.AreEqual(OriginalEmailAddress, _customer.Email);
            }

            [Test]
            public void TheResponseIsNotSuccessful()
            {
                Assert.IsFalse(_response.IsOk);
            }

            [Test]
            public void TheResponseMessageIsCorrect()
            {
                Assert.AreEqual("Email is not valid", _response.Message);
            }
        }
    }
}
