using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyPegasus.Web.Models.Trip;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Controllers
{
    [Authorize]
    public class TripController : AsyncController
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpGet]
        public async Task<ActionResult> IndexAsync(Guid customerId)
        {
            var trips = await _tripService.RetrieveTripsForCustomerAsync(customerId);
            var model = new AllTripsViewModel
            {
                CustomerId = customerId,
                Trips = trips
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Create(Guid customerId)
        {
            var newTrip = new CreateTripViewModel {CustomerId = customerId};
            return View(newTrip);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(CreateTripViewModel trip)
        {
            await _tripService.CreateTripAsync(trip);
            return RedirectToAction("Index", new {customerId = trip.CustomerId});
        }
    }
}