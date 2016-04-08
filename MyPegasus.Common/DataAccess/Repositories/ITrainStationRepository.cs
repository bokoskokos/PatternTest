using System.Threading.Tasks;
using MyPegasus.Common.DomainModel.Models;

namespace MyPegasus.Common.DataAccess.Repositories
{
    public interface ITrainStationRepository
    {
        Task<ITrainStation> RetrieveTrainStationByIdAsync(int id);
    }
}
