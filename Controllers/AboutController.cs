using Microsoft.AspNetCore.Mvc;

namespace CrazyCatsWeb.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
