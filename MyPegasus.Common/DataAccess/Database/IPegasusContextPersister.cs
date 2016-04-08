using System.Threading.Tasks;

namespace MyPegasus.Common.DataAccess.Database
{
    public interface IPegasusContextPersister
    {
        Task SaveAsync();
    }
}
