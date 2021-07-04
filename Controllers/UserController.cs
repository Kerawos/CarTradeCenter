using Microsoft.AspNetCore.Mvc;


namespace CarTradeCenter.Controllers
{
    public class UserController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}
