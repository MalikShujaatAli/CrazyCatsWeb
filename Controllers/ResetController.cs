using Microsoft.AspNetCore.Mvc;
using CrazyCatsWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CrazyCatsWeb.Controllers
{
    public class ResetController : Controller
    {
        private readonly CrazyCatsContext _context;

        public ResetController(CrazyCatsContext context)
        {
            _context = context;
        }

        // GET: /Reset
        public IActionResult Reset()
        {
            return View();
        }

        // POST: /Reset
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string email)
        {
            // Check if the user exists with the provided email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user != null)
            {
                // Here you would typically generate a password reset token and send an email
                // For demonstration, we'll just return a view to reset the password
                return View("ResetConfirmation", user); // Pass the user to the confirmation view
            }
            else
            {
                ModelState.AddModelError("", "No user found with this email address.");
            }

            return View(); // Return to the reset view if the email is not found
        }

        // POST: /Reset/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(string newPassword, string confirmPassword, string email)
        {
            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return View("ResetConfirmation", new User { Email = email }); // Return to the confirmation view with an error
            }

            // Find the user by email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                // Update the user's password (ensure to hash the password before saving)
                user.Password = newPassword; // Ideally, hash the password here
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                // Redirect to a success page or login page
                return RedirectToAction("Login", "Login"); // Ensure this points to your Login controller
            }

            ModelState.AddModelError("", "User  not found.");
            return View("ResetConfirmation", new User { Email = email }); // Return to the confirmation view with an error
        }
    }
}