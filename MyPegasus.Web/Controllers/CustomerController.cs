using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyPegasus.Web.Models.Customer;
using MyPegasus.Web.Services.Contracts;

namespace MyPegasus.Web.Controllers
{
    [Authorize]
    public class CustomerController : AsyncController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult> Customer(Guid id)
        {
            var response = await _customerService.RetrieveByIdAsync(id);
            return View(response);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateCustomerViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCustomerViewModel model)
        {
            await _customerService.CreateAsync(model);
            return View(new CreateCustomerViewModel());
        }
    }
}