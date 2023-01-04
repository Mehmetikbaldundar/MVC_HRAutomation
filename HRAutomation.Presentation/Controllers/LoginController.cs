using HRAutomation.DataAccess.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HRAutomation.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminRepo _adminRepo;
        private readonly IEmployeeRepo _employeeRepo;

        public LoginController(IAdminRepo adminRepo, IEmployeeRepo employeeRepo)
        {
            _adminRepo = adminRepo;
            _employeeRepo = employeeRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string emailAddress, string password)
        {
            var adminUser = await _adminRepo.GetByEmail(emailAddress, password);

            var claims = new List<Claim>();

            if (adminUser != null)            
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            
            var userIdentity = new ClaimsIdentity(claims,"Admin");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            if (adminUser != null)
                return RedirectToAction("Index", "Admin", new { area = "Admin" });

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
