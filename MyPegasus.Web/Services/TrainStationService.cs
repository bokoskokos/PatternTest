using System.Threading.Tasks;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Services
{
    public class TrainStationService : ServiceBase, ITrainStationService
    {
        public async Task<string> RetrieveTrainStationByIdAsync(int id)
        {
            var request = new RetrieveTrainStationByIdHandlerRequest {TrainStationId = id};
            var response = await CallHandlerAsync<RetrieveTrainStationByIdHandlerRequest, RetrieveTrainStationByIdHandlerResponse>(request);
            return response.TrainStationName;
        }
    }
}