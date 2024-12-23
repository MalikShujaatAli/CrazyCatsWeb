using Microsoft.AspNetCore.Mvc;
using CrazyCatsWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;


namespace CrazyCatsWeb.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CrazyCatsContext _context;

        public RegisterController(CrazyCatsContext context)
        {
            _context = context;
        }

        // GET: /Register
        public IActionResult Register()
        {
            return View();
        }



        // POST: /Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User model, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                // Check if the username or email already exists
                if (await _context.Users.AnyAsync(u => u.Username == model.Username || u.Email == model.Email))
                {
                    ModelState.AddModelError("", "Username or email already exists.");
                    return View(model);
                }

                // Check if passwords match
                if (model.Password != confirmPassword)
        {
                    ModelState.AddModelError("", "Passwords do not match.");
                    return View(model);
                }

                // Store the user with the selected role
                _context.Users.Add(model);
                await _context.SaveChangesAsync();

                // Redirect to a success page or login page
                return RedirectToAction("Login", "Login");
            }

            return View(model);
        }
    }
}