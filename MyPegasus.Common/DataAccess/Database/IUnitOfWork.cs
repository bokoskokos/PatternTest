using System.Threading.Tasks;

namespace MyPegasus.Common.DataAccess.Database
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
