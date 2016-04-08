using System.Threading.Tasks;

namespace MyPegasus.Web.Services.Contracts
{
    public interface ITrainStationService : IService
    {
        Task<string> RetrieveTrainStationByIdAsync(int id);
    }
}
