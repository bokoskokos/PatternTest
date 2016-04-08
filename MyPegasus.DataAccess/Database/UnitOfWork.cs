using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Database;

namespace MyPegasus.DataAccess.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IPegasusContextPersister _pegasusContextPersister;

        public UnitOfWork(IPegasusContextPersister pegasusContextPersister)
        {
            _pegasusContextPersister = pegasusContextPersister;
        }

        public async Task SaveAsync()
        {
            await _pegasusContextPersister.SaveAsync();
        }
    }
}
