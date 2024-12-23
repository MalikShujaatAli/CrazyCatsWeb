using Microsoft.AspNetCore.Mvc;
using CrazyCatsWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrazyCatsWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly CrazyCatsContext _context;

        public LoginController(CrazyCatsContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View("Login");
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Check if the user exists
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // User is authenticated, check their role
                switch (user.Role.Trim()) // Trim to avoid issues with extra spaces
                {
                    case "Admin":
                        return RedirectToAction("Index", "Home"); // Dummy view for Admin
                    case "Moderator":
                        return RedirectToAction("Index", "Home"); // Dummy view for Moderator
                    case "User ":
                    default:
                        return RedirectToAction("Index", "Home"); // Dummy view for User
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(); // Return to the login view if authentication fails
        }
    }
}