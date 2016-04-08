using System.Threading.Tasks;
using System.Web.Mvc;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Controllers
{
    public class TrainStationController : AsyncController
    {
        private readonly ITrainStationService _trainStationService;

        public TrainStationController(ITrainStationService trainStationService)
        {
            _trainStationService = trainStationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> TrainStationById(int id)
        {
            return await _trainStationService.RetrieveTrainStationByIdAsync(id);
        }
    }
}