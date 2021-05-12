using Microsoft.AspNetCore.Mvc;


namespace CarTradeCenter.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
