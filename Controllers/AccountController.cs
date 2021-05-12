using Microsoft.AspNetCore.Mvc;


namespace CarTradeCenter.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
