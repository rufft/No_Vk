using Microsoft.AspNetCore.Mvc;

namespace No_Vk.Domain.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
