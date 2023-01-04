using Microsoft.AspNetCore.Mvc;

namespace NRM1_HastaneOtomasyon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonnelController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
