using HRAutomation.Business.Models.DTOs;
using HRAutomation.Business.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace NRM1_HastaneOtomasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagerController : Controller
    {       
        private readonly IAdminService _adminService;
        public ManagerController(IAdminService adminService)
        {
            _adminService= adminService;
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

        public async Task<IActionResult> ListOfManagers()
        {
            var managers = await _adminService.ListOfManagers();
            return View(managers);
        }

        public async Task<IActionResult> UpdateManager(Guid id)
        {
            var updateManager = await _adminService.GetManager(id);
            return View(updateManager);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManager(UpdateManagerDTO updateManagerDTO)
        {
            await _adminService.UpdateManager(updateManagerDTO);
            return RedirectToAction(nameof(ListOfManagers));
        }
    }
}
