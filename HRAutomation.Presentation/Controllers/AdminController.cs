using HRAutomation.Business.Models.DTOs;
using HRAutomation.Business.Services.AdminService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRAutomation.Presentation.Controllers
{
    [Authorize(Roles ="Admin")]
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

        public IActionResult AddManager()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddManager(addManagerDTO);
                return RedirectToAction("ListOfManagers");
            }
            return View(addManagerDTO);
        }
    }
}
