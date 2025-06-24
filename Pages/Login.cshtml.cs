using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace MTRADashboard.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // If user is signing out
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync("Cookies");
                return RedirectToPage("/Login");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: Add proper authentication logic here
            // This is just a basic example - in a real application, you would validate against a database
            if (Email == "user@adnoc.ae" && Password == "password")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email),
                    new Claim(ClaimTypes.Email, Email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = RememberMe,
                    RedirectUri = Url.Page("/Index")
                };

                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
} 