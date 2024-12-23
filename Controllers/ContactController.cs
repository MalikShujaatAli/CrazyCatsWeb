using Microsoft.AspNetCore.Mvc;

namespace CrazyCatsWeb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View("Contact");
        }
    }
}
