using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.DomainModel.Models;
using MyPegasus.DataAccess.DeutscheBahnApi.Dtos;
using MyPegasus.DataAccess.DeutscheBahnApi;

namespace MyPegasus.DataAccess.Repositories
{
    public class TrainStationRepository : ITrainStationRepository
    {
        private readonly IDeutscheBahnApiClient _deutscheBahnApiClient;

        public TrainStationRepository(IDeutscheBahnApiClient deutscheBahnApiClient)
        {
            _deutscheBahnApiClient = deutscheBahnApiClient;
        }

        public async Task<ITrainStation> RetrieveTrainStationByIdAsync(int id)
        {
            var uri = @"http://adam.noncd.db.de/api/v1.0/stations/" + id;
            var response = await _deutscheBahnApiClient.GetAsync<TrainStation>(uri);
            return response;
        }
    }
}
