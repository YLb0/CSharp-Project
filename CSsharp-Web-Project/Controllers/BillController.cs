//using Microsoft.AspNetCore.Mvc;
//using ProductSystem.Services.Data.Interfaces;
//using System.Security.Claims;

//namespace CSsharp_Web_Project.Controllers
//{
//    public class BillController : Controller
//    {
//        private readonly IBillService billService;

//        public BillController(IBillService billService)
//        {
//            this.billService = billService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddToBills(string id)
//        {
//            var cart = await billService.GetCartByIdAsync(id);

//            if (cart == null)
//            {
//                return RedirectToAction(nameof(MyBill));
//            }
//            if (!ModelState.IsValid)
//            {
//                return View();
//            }

//            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
//            // var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

//            try
//            {
//                await billService.AddCartToBillAsync(userId, cart);

//                return RedirectToAction("MyCart", "Cart");
//            }
//            catch (Exception)
//            {
//                return RedirectToAction(nameof(MyBill));
//            }
//        }

//        public async Task<IActionResult> MyBill()
//        {
//            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

//            try
//            {
//                var model = await billService.GetMyBillAsync(userId);

//                return View(model);
//            }
//            catch (Exception)
//            {
//                return RedirectToAction("All", "Product");
//            }
//        }
//    }
//}
