using System;
using System.Data.Entity;
using System.Linq;
using Moq;
using MyPegasus.DataAccess.Database;
using MyPegasus.DomainModel.Models;

namespace MyPegasus.DataAccess.Tests.Database
{
    public class MockPegasusContextProvider
    {
        private readonly Mock<IPegasusContext> _context;

        public MockPegasusContextProvider()
        {
            _context = new Mock<IPegasusContext>();
        }

        public IPegasusContext Context => _context?.Object;

        public void SetUpDbSet<TEntity>(IQueryable<TEntity> entities)
            where TEntity : class
        {
            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(entities.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(entities.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(entities.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator);

            if (typeof(TEntity) == typeof(Trip))
                _context.Setup(mock => mock.Trips).Returns(mockSet.Object as DbSet<Trip>);
            else if (typeof(TEntity) == typeof(Customer))
                _context.Setup(mock => mock.Customers).Returns(mockSet.Object as DbSet<Customer>);
            else if (typeof(TEntity) == typeof(Account))
                _context.Setup(mock => mock.Users).Returns(mockSet.Object as DbSet<Account>);
            else
                throw new Exception($"DbSet entity type: {typeof(TEntity)} is not handled by the MockPegasusContextProvider. Please add it to method SetUpDbSet<TEntity>");
        }
    }
}
