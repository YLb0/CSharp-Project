using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineSh0p.Web.Infrastructure.Extensions;
using ProductSystem.Services.Data.Interfaces;
using ShopSystems.Web.ViewModels.Client;

namespace CSsharp_Web_Project.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task<IActionResult> All()
        {
            if (!this.User.IsAdmin())
            {
                return RedirectToAction("Index", "Home");
            }
            var model = await clientService.GetMyOrdersAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddClientViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await clientService.AddClient(model);

            return RedirectToAction("Index", "Home");
        }

        //public async Task<IActionResult> AddOrder(string billId, string clientId)
        //{
        //    var bill = await clientService.GetBillByIdAsync(billId);

        //    var client = await clientService.GetClientByIdAsync(clientId);

        //    await clientService.AddOrder(bill, client);

        //    return RedirectToAction("All", "Product");
        //}
    }
}
