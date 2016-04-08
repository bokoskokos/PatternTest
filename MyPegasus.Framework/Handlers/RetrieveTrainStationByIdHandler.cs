using System.Threading.Tasks;
using MyPegasus.Common.DataAccess.Repositories;
using MyPegasus.Common.Framework;
using MyPegasus.Framework.HandlerRequests;
using MyPegasus.Framework.HandlerResponses;

namespace MyPegasus.Framework.Handlers
{
    public class RetrieveTrainStationByIdHandler : IHandler<RetrieveTrainStationByIdHandlerRequest, RetrieveTrainStationByIdHandlerResponse>
    {
        private readonly ITrainStationRepository _trainStationRepository;

        public RetrieveTrainStationByIdHandler(ITrainStationRepository trainStationRepository)
        {
            _trainStationRepository = trainStationRepository;
        }

        public async Task<RetrieveTrainStationByIdHandlerResponse> HandleAsync(RetrieveTrainStationByIdHandlerRequest request)
        {
            var trainStation = await _trainStationRepository.RetrieveTrainStationByIdAsync(request.TrainStationId);
            return new RetrieveTrainStationByIdHandlerResponse {TrainStationName = trainStation?.Name};
        }
    }
}
