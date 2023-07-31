//using Microsoft.AspNetCore.Mvc;
//using ProductSystem.Services.Data;
//using ProductSystem.Services.Data.Interfaces;
//using ShopSystems.Web.ViewModels.Client;

//namespace CSsharp_Web_Project.Controllers
//{
//    public class ClientController : Controller
//    {
//        private readonly IClientService clientService;

//        public ClientController(IClientService clientService)
//        {
//            this.clientService = clientService;
//        }

//        public async Task<IActionResult> All()
//        {
//            var model = await clientService.GetMyOrdersAsync();

//            return View(model);
//        }

//        [HttpGet]
//        public IActionResult Add()
//        {
//            var model = new AddClientViewModel();

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add(AddClientViewModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            await clientService.AddClient(model);

//            return RedirectToAction("All", "Product");
//        }

//        public async Task<IActionResult> AddOrder(string billId, string clientId)
//        {
//            var bill = await clientService.GetBillByIdAsync(billId);

//            var client = await clientService.GetClientByIdAsync(clientId);

//            await clientService.AddOrder(bill, client);

//            return RedirectToAction("All", "Product");
//        }
//    }
//}
