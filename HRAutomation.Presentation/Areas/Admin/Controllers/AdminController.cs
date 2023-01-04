using HRAutomation.Business.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace NRM1_HastaneOtomasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }       
        public IActionResult Index()
        {
            return View();
        }        
    }
}
