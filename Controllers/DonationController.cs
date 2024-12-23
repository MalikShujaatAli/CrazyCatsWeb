using Microsoft.AspNetCore.Mvc;

namespace CrazyCatsWeb.Controllers
{
    public class DonationController : Controller
    {
        public IActionResult Donation()
        {
            return View("Donation");
        }
    }
}
